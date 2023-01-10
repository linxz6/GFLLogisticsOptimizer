using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GFLLogisticsOptimizerWpf
{
    public struct LogisticsMission
    {
        public string Area;
        public double Manpower;
        public double Ammo;
        public double Rations;
        public double Parts;
        public int TimeMins;
        public double TDollContracts;
        public double EquipmentContracts;
        public double QuickProduceContracts;
        public double QuickRepairContracts;
        public double Tokens;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<LogisticsMission> MissionList = new List<LogisticsMission>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public double CalculateMissionValuePerMin(LogisticsMission Mission,double ManpowerWeight,double AmmoWeight,double RationWeight,double PartWeight,double TDollWeight,double EquipmentWeight,double QuickProduceWeight,double QuickRepairWeight,double TokenWeight)
        {
            double ValuePerMin = 0;

            ValuePerMin += Mission.Manpower * ManpowerWeight / Mission.TimeMins;
            ValuePerMin += Mission.Ammo * AmmoWeight / Mission.TimeMins;
            ValuePerMin += Mission.Rations * RationWeight / Mission.TimeMins;
            ValuePerMin += Mission.Parts * PartWeight / Mission.TimeMins;
            ValuePerMin += Mission.TDollContracts * TDollWeight / Mission.TimeMins;
            ValuePerMin += Mission.EquipmentContracts * EquipmentWeight / Mission.TimeMins;
            ValuePerMin += Mission.QuickProduceContracts * QuickProduceWeight / Mission.TimeMins;
            ValuePerMin += Mission.QuickRepairContracts * QuickRepairWeight / Mission.TimeMins;
            ValuePerMin += Mission.Tokens * TokenWeight / Mission.TimeMins;

            return ValuePerMin;
        }

        public double CalculateCraftsPerMin(LogisticsMission[] MissionSet,double ManpowerNeeded,double AmmoNeeded,double RationNeeded,double PartNeeded,double TDollNeeded,double EquipmentNeeded,double QuickProduceNeeded,double QuickRepairNeeded,double TokenNeeded)
        {
            double CraftsPerMin = 10000000;

            double ManpowerCraftsPerMin = 0;
            double AmmoCraftsPerMin = 0;
            double RationCraftsPerMin = 0;
            double PartCraftsPerMin = 0;
            double TDollCraftsPerMin = 0;
            double EquipmentCraftsPerMin = 0;
            double QuickProduceCraftsPerMin = 0;
            double QuickRepairCraftsPerMin = 0;
            double TokenCraftsPerMin = 0;
            for (int i = 0;i < MissionSet.Count();i++)
            {
                ManpowerCraftsPerMin += MissionSet[i].Manpower / ManpowerNeeded / MissionSet[i].TimeMins;
                AmmoCraftsPerMin += MissionSet[i].Ammo / AmmoNeeded / MissionSet[i].TimeMins;
                RationCraftsPerMin += MissionSet[i].Rations / RationNeeded / MissionSet[i].TimeMins;
                PartCraftsPerMin += MissionSet[i].Parts / PartNeeded / MissionSet[i].TimeMins;
                TDollCraftsPerMin += MissionSet[i].TDollContracts / TDollNeeded / MissionSet[i].TimeMins;
                EquipmentCraftsPerMin += MissionSet[i].EquipmentContracts / EquipmentNeeded / MissionSet[i].TimeMins;
                QuickProduceCraftsPerMin += MissionSet[i].QuickProduceContracts / QuickProduceNeeded / MissionSet[i].TimeMins;
                QuickRepairCraftsPerMin += MissionSet[i].QuickRepairContracts / QuickRepairNeeded / MissionSet[i].TimeMins;
                TokenCraftsPerMin += MissionSet[i].Tokens / TokenNeeded / MissionSet[i].TimeMins;
            }

            if(ManpowerNeeded > 0 && ManpowerCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = ManpowerCraftsPerMin;
            }
            if (AmmoNeeded > 0 && AmmoCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = ManpowerCraftsPerMin;
            }
            if (RationNeeded > 0 && RationCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = RationCraftsPerMin;
            }        
            if (PartNeeded > 0 && PartCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = PartCraftsPerMin;
            }
            if (TDollNeeded > 0 && TDollCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = TDollCraftsPerMin;
            }
            if (EquipmentNeeded > 0 && EquipmentCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = EquipmentCraftsPerMin;
            }
            if (QuickProduceNeeded > 0 && QuickProduceCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = QuickProduceCraftsPerMin;
            }
            if (QuickRepairNeeded > 0 && QuickRepairCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = QuickRepairCraftsPerMin;
            }
            if (TokenNeeded > 0 && TokenCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = TokenCraftsPerMin;
            }

            return CraftsPerMin;
        }

        public bool LoadMissionData(string FilePath)
        {
            MissionList.Clear();
            try
            {
                using (var reader = new StreamReader(FilePath))
                {
                    //ignore the first line which is the header
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        var values = line.Split(',');

                        LogisticsMission NewMission = new LogisticsMission();
                        NewMission.Area = values[0].Replace('.', '-');
                        NewMission.Manpower = Convert.ToDouble(values[1]);
                        NewMission.Ammo = Convert.ToDouble(values[2]);
                        NewMission.Rations = Convert.ToDouble(values[3]);
                        NewMission.Parts = Convert.ToDouble(values[4]);
                        NewMission.TimeMins = Convert.ToInt32(values[5]);
                        NewMission.TDollContracts = Convert.ToDouble(values[6]);
                        NewMission.EquipmentContracts = Convert.ToDouble(values[7]);
                        NewMission.QuickProduceContracts = Convert.ToDouble(values[8]);
                        NewMission.QuickRepairContracts = Convert.ToDouble(values[9]);
                        NewMission.Tokens = Convert.ToDouble(values[10]);

                        MissionList.Add(NewMission);
                    }                
                }
                return true;
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Failed to read mission data: " + Ex.Message);
                return false;
            }
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMissionData(@"..\..\..\..\Logistics Data.csv");
        }
    }
}
