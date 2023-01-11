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
    public class LogisticsMission : IComparable
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
        public override string ToString()
        {
            return Area;
        }
        public int CompareTo(object obj)
        {
            if(obj == null)
            {
                return 1;
            }

            LogisticsMission otherMission = obj as LogisticsMission;
            if(otherMission == null)
            {
                return 1;
            }
            return this.Area.CompareTo(otherMission.Area);
        }
    }

    public class MissionValuePerMin
    {
        public LogisticsMission Mission;
        public double ValuePerMin;
        public override string ToString()
        {
            return Mission.Area;
        }
    }

    public class MissionSetCraftsPerMin
    {
        public List<LogisticsMission> MissionSet;
        public double CraftsPerMin;

        public override string ToString()
        {
            string output = string.Empty;

            for(int i = 0;i < MissionSet.Count;i++)
            {
                output += MissionSet[i].ToString();
                if(i != MissionSet.Count - 1)
                {
                    output += ',';
                }
            }

            return output;
        }
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

        List<List<T>> GetKCombs<T>(List<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t }.ToList()).ToList();

            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0).ToList(),
                    (t1, t2) => t1.Concat(new T[] { t2 }).ToList()).ToList();
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

        public double CalculateCraftsPerMin(List<LogisticsMission> MissionSet,double ManpowerNeeded,double AmmoNeeded,double RationNeeded,double PartNeeded,double TDollNeeded,double EquipmentNeeded,double QuickProduceNeeded,double QuickRepairNeeded,double TokenNeeded)
        {
            double CraftsPerMin = 10000000;

            //get the crafts per minute allow by each resource
            double ManpowerCraftsPerMin = 0;
            double AmmoCraftsPerMin = 0;
            double RationCraftsPerMin = 0;
            double PartCraftsPerMin = 0;
            double TDollCraftsPerMin = 0;
            double EquipmentCraftsPerMin = 0;
            double QuickProduceCraftsPerMin = 0;
            double QuickRepairCraftsPerMin = 0;
            double TokenCraftsPerMin = 0;
            for (int i = 0;i < MissionSet.Count;i++)
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

            //the smallest crafts per minute is the overall rate
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

        public bool LoadMissionData(string FilePath,double GreatSuccessRate,double BaseRankBonus)
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
                        NewMission.Manpower = Convert.ToDouble(values[1]) * (BaseRankBonus + 1.0) * (1 + 0.5 * GreatSuccessRate);
                        NewMission.Ammo = Convert.ToDouble(values[2]) * (BaseRankBonus + 1.0) * (1 + 0.5 * GreatSuccessRate);
                        NewMission.Rations = Convert.ToDouble(values[3]) * (BaseRankBonus + 1.0) * (1 + 0.5 * GreatSuccessRate);
                        NewMission.Parts = Convert.ToDouble(values[4]) * (BaseRankBonus + 1.0) * (1 + 0.5 * GreatSuccessRate);
                        NewMission.TimeMins = Convert.ToInt32(values[5]);
                        NewMission.TDollContracts = Convert.ToDouble(values[6]);
                        NewMission.EquipmentContracts = Convert.ToDouble(values[7]);
                        NewMission.QuickProduceContracts = Convert.ToDouble(values[8]);
                        NewMission.QuickRepairContracts = Convert.ToDouble(values[9]);
                        NewMission.Tokens = Convert.ToDouble(values[10]);

                        //calculate the effect of great success on the chance of getting bonus items
                        double TotalChanceItemBeforeGreatSuccess = NewMission.TDollContracts + NewMission.EquipmentContracts + NewMission.QuickProduceContracts + NewMission.QuickRepairContracts + NewMission.Tokens;
                        if (TotalChanceItemBeforeGreatSuccess > 0)
                        {
                            double TotalChanceItemAfterGreatSuccess = GreatSuccessRate + TotalChanceItemBeforeGreatSuccess * (1 - GreatSuccessRate);
                            double GreatSuccessBonus = TotalChanceItemAfterGreatSuccess - TotalChanceItemBeforeGreatSuccess;

                            NewMission.TDollContracts += (NewMission.TDollContracts / TotalChanceItemBeforeGreatSuccess) * GreatSuccessBonus;
                            NewMission.EquipmentContracts += (NewMission.EquipmentContracts / TotalChanceItemBeforeGreatSuccess) * GreatSuccessBonus;
                            NewMission.QuickProduceContracts += (NewMission.QuickProduceContracts / TotalChanceItemBeforeGreatSuccess) * GreatSuccessBonus;
                            NewMission.QuickRepairContracts += (NewMission.QuickRepairContracts / TotalChanceItemBeforeGreatSuccess) * GreatSuccessBonus;
                            NewMission.Tokens += (NewMission.Tokens / TotalChanceItemBeforeGreatSuccess) * GreatSuccessBonus;
                        }
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

        public int CompareMissionSetCraftsPerMin(MissionSetCraftsPerMin A,MissionSetCraftsPerMin B)
        {
            if(A.CraftsPerMin < B.CraftsPerMin)
            {
                return -1;
            }
            else if(A.CraftsPerMin > B.CraftsPerMin)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void OptimizeButton_Click(object sender, RoutedEventArgs e)
        {
            //check that all the input weights/craft amounts are valid numbers 
            if(MissionList.Count > 4)
            {
                if (OptimizationTypeComboBox.SelectedIndex == 0)
                {

                }
                if (OptimizationTypeComboBox.SelectedIndex == 1)
                {
                    var all_mission_sets = GetKCombs(MissionList, 4).ToList();

                    List<MissionSetCraftsPerMin> MissionSets = new List<MissionSetCraftsPerMin>();
                    MissionSets.Capacity = all_mission_sets.Count;
                    for(int i = 0;i < all_mission_sets.Count;i++)
                    {
                        MissionSetCraftsPerMin NewMissionSet = new MissionSetCraftsPerMin();
                        NewMissionSet.CraftsPerMin = CalculateCraftsPerMin(all_mission_sets[i], Convert.ToDouble(ManpowerTextBox.Text), Convert.ToDouble(AmmoTextBox.Text), Convert.ToDouble(RationsTextBox.Text), Convert.ToDouble(PartsTextBox.Text), Convert.ToDouble(TDollTextBox.Text), Convert.ToDouble(EquipTextBox.Text), Convert.ToDouble(QuickProductionTextBox.Text), Convert.ToDouble(QuickRepairTextBox.Text), Convert.ToDouble(TokenTextBox.Text));
                        if(NewMissionSet.CraftsPerMin <= 0)
                        {
                            continue;
                        }
                        NewMissionSet.MissionSet = all_mission_sets[i];                       
                        MissionSets.Add(NewMissionSet);
                    }

                    MissionSets.Sort(CompareMissionSetCraftsPerMin);
                    MissionSets.Reverse();

                    bool foo = true;
                }
            }
            else
            {
                MessageBox.Show("No point optimizing if there are fewer than 4 valid missions");
            }
        }

        private void OptimizationTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(OptimizationTypeComboBox.SelectedIndex == 0)
            {
                ResourceLabel.Content = "Resource Weights";
            }
            if(OptimizationTypeComboBox.SelectedIndex == 1)
            {
                ResourceLabel.Content = "Resources Per Craft";
            }
        }

        private void LoadMissionsButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentValidMissionsListBox.Items.Clear();
            LoadMissionData(@"..\..\..\..\Logistics Data.csv", 0.66, 0.11);
            if(MissionList.Count > 0)
            {
                for(int i = 0;i < MissionList.Count;i++)
                {
                    CurrentValidMissionsListBox.Items.Add(MissionList[i].ToString());
                }
            }
        }
    }
}
