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
        public string Area { get; set; }
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

        //string convertors for the display
        public bool PerHourDisplay = false;
        public string ManpowerString
        {
            get
            {
                if (PerHourDisplay)
                {
                    return Math.Round(Manpower / TimeMins * 60.0).ToString();
                }
                else
                {
                    return Math.Round(Manpower).ToString();
                }
            }
        }
        public string AmmoString
        {
            get
            {
                if (PerHourDisplay)
                {
                    return Math.Round(Ammo / TimeMins * 60.0).ToString();
                }
                else
                {
                    return Math.Round(Ammo).ToString();
                }
            }
        }
        public string RationString
        {
            get
            {
                if (PerHourDisplay)
                {
                    return Math.Round(Rations / TimeMins * 60.0).ToString();
                }
                else
                {
                    return Math.Round(Rations).ToString();
                }
            }
        }
        public string PartString
        {
            get
            {
                if (PerHourDisplay)
                {
                    return Math.Round(Parts / TimeMins * 60.0).ToString();
                }
                else
                {
                    return Math.Round(Parts).ToString();
                }
            }
        }
        public string TimeString
        {
            get
            {
                string output = (TimeMins / 60).ToString() + ":" + (TimeMins % 60).ToString();
                if(TimeMins % 60 == 0)
                {
                    output += "0";
                }
                return output;
            }
        }
        public string Bonus1String
        {
            get
            {
                if (TDollContracts > 0)
                {
                    if (PerHourDisplay)
                    {
                        return (TDollContracts / TimeMins * 60.0).ToString("G3");
                    }
                    else
                    {
                        return (TDollContracts).ToString("G3");
                    }
                }
                if (EquipmentContracts > 0)
                {
                    if (PerHourDisplay)
                    {
                        return (EquipmentContracts / TimeMins * 60.0).ToString("G3");
                    }
                    else
                    {
                        return (EquipmentContracts).ToString("G3");
                    }
                }
                if (QuickProduceContracts > 0)
                {
                    if (PerHourDisplay)
                    {
                        return (QuickProduceContracts / TimeMins * 60.0).ToString("G3");
                    }
                    else
                    {
                        return (QuickProduceContracts).ToString("G3");
                    }
                }
                if (QuickRepairContracts > 0)
                {
                    if (PerHourDisplay)
                    {
                        return (QuickRepairContracts / TimeMins * 60.0).ToString("G3");
                    }
                    else
                    {
                        return (QuickRepairContracts).ToString("G3");
                    }
                }
                if (Tokens > 0)
                {
                    if (PerHourDisplay)
                    {
                        return (Tokens / TimeMins * 60.0).ToString("G3");
                    }
                    else
                    {
                        return (Tokens).ToString("G3");
                    }
                }
                return string.Empty;
            }
        }
        public string Bonus1Path
        {
            get
            {
                if (TDollContracts > 0)
                {
                    return @"\..\..\images\tdoll contract.png";
                }
                if (EquipmentContracts > 0)
                {
                    return @"\..\..\images\equipment contract.png";
                }
                if (QuickProduceContracts > 0)
                {
                    return @"\..\..\images\quick production.png";
                }
                if (QuickRepairContracts > 0)
                {
                    return @"\..\..\images\quick repair.png";
                }
                if (Tokens > 0)
                {
                    return @"\..\..\images\token.png";
                }
                return string.Empty;
            }
        }
        public string Bonus2String
        {
            get
            {
                bool bonus1found = false;
                if (TDollContracts > 0)
                {
                    if (bonus1found)
                    {
                        if (PerHourDisplay)
                        {
                            return (TDollContracts / TimeMins * 60.0).ToString("G3");
                        }
                        else
                        {
                            return (TDollContracts).ToString("G3");
                        }
                    }
                    bonus1found = true;
                }
                if (EquipmentContracts > 0)
                {
                    if (bonus1found)
                    {
                        if (PerHourDisplay)
                        {
                            return (EquipmentContracts / TimeMins * 60.0).ToString("G3");
                        }
                        else
                        {
                            return (EquipmentContracts).ToString("G3");
                        }
                    }
                    bonus1found = true;
                }
                if (QuickProduceContracts > 0)
                {
                    if (bonus1found)
                    {
                        if (PerHourDisplay)
                        {
                            return (QuickProduceContracts / TimeMins * 60.0).ToString("G3");
                        }
                        else
                        {
                            return (QuickProduceContracts).ToString("G3");
                        }
                    }
                    bonus1found = true;
                }
                if (QuickRepairContracts > 0)
                {
                    if (bonus1found)
                    {
                        if (PerHourDisplay)
                        {
                            return (QuickRepairContracts / TimeMins * 60.0).ToString("G3");
                        }
                        else
                        {
                            return (QuickRepairContracts).ToString("G3");
                        }
                    }
                    bonus1found = true;
                }
                if (Tokens > 0)
                {
                    if (bonus1found)
                    {
                        if (PerHourDisplay)
                        {
                            return (Tokens / TimeMins * 60.0).ToString("G3");
                        }
                        else
                        {
                            return (Tokens).ToString("G3");
                        }
                    }
                    bonus1found = true;
                }
                return string.Empty;
            }
        }
        public string Bonus2Path
        {
            get
            {
                bool bonus1found = false;
                if (TDollContracts > 0)
                {
                    if (bonus1found)
                    {
                        return @"\..\..\images\tdoll contract.png";
                    }
                    bonus1found = true;
                }
                if (EquipmentContracts > 0)
                {                   
                    if (bonus1found)
                    {
                        return @"\..\..\images\equipment contract.png";
                    }
                    bonus1found = true;
                }
                if (QuickProduceContracts > 0)
                {                   
                    if (bonus1found)
                    {
                        return @"\..\..\images\quick production.png";
                    }
                    bonus1found = true;
                }
                if (QuickRepairContracts > 0)
                {
                    if (bonus1found)
                    {
                        return @"\..\..\images\quick repair.png";
                    }
                    bonus1found = true;
                }
                if (Tokens > 0)
                {
                    if (bonus1found)
                    {
                        return @"\..\..\images\token.png";
                    }
                    bonus1found = true;
                }
                return string.Empty;
            }
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
        public double CraftWeighedResourcesPerMin;

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
                if (ManpowerNeeded > 0)
                {
                    ManpowerCraftsPerMin += MissionSet[i].Manpower / ManpowerNeeded / MissionSet[i].TimeMins;
                }
                if (AmmoNeeded > 0)
                {
                    AmmoCraftsPerMin += MissionSet[i].Ammo / AmmoNeeded / MissionSet[i].TimeMins;
                }
                if (RationNeeded > 0)
                {
                    RationCraftsPerMin += MissionSet[i].Rations / RationNeeded / MissionSet[i].TimeMins;
                }
                if (PartNeeded > 0)
                {
                    PartCraftsPerMin += MissionSet[i].Parts / PartNeeded / MissionSet[i].TimeMins;
                }
                if (TDollNeeded > 0)
                {
                    TDollCraftsPerMin += MissionSet[i].TDollContracts / TDollNeeded / MissionSet[i].TimeMins;
                }
                if (EquipmentNeeded > 0)
                {
                    EquipmentCraftsPerMin += MissionSet[i].EquipmentContracts / EquipmentNeeded / MissionSet[i].TimeMins;
                }
                if (QuickProduceNeeded > 0)
                {
                    QuickProduceCraftsPerMin += MissionSet[i].QuickProduceContracts / QuickProduceNeeded / MissionSet[i].TimeMins;
                }
                if (QuickRepairNeeded > 0)
                {
                    QuickRepairCraftsPerMin += MissionSet[i].QuickRepairContracts / QuickRepairNeeded / MissionSet[i].TimeMins;
                }
                if (TokenNeeded > 0)
                {
                    TokenCraftsPerMin += MissionSet[i].Tokens / TokenNeeded / MissionSet[i].TimeMins;
                }
            }

            //the smallest crafts per minute is the overall rate
            if(ManpowerNeeded > 0 && ManpowerCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = ManpowerCraftsPerMin;
            }
            if (AmmoNeeded > 0 && AmmoCraftsPerMin < CraftsPerMin)
            {
                CraftsPerMin = AmmoCraftsPerMin;
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

        public double CalculateCraftWeightedValuePerMin(List<LogisticsMission> MissionSet, double ManpowerNeeded, double AmmoNeeded, double RationNeeded, double PartNeeded, double TDollNeeded, double EquipmentNeeded, double QuickProduceNeeded, double QuickRepairNeeded, double TokenNeeded)
        {
            double CraftValuePerMin = 0;
            int TypesOfResourceNeeded = 0;
            if(ManpowerNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (AmmoNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (RationNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (PartNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (TDollNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (EquipmentNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (QuickProduceNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (QuickRepairNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }
            if (TokenNeeded > 0)
            {
                TypesOfResourceNeeded++;
            }

            for(int i = 0;i < MissionSet.Count;i++)
            {
                if (ManpowerNeeded > 0 && MissionSet[i].Manpower > 0)
                {
                    CraftValuePerMin += MissionSet[i].Manpower / ManpowerNeeded / MissionSet[i].TimeMins;
                }
                if (AmmoNeeded > 0 && MissionSet[i].Ammo > 0)
                {
                    CraftValuePerMin += MissionSet[i].Ammo / AmmoNeeded / MissionSet[i].TimeMins;
                }
                if (RationNeeded > 0 && MissionSet[i].Rations > 0)
                {
                    CraftValuePerMin += MissionSet[i].Rations / RationNeeded / MissionSet[i].TimeMins;
                }
                if (PartNeeded > 0 && MissionSet[i].Parts > 0)
                {
                    CraftValuePerMin += MissionSet[i].Parts / PartNeeded / MissionSet[i].TimeMins;
                }
                if (TDollNeeded > 0 && MissionSet[i].TDollContracts > 0)
                {
                    CraftValuePerMin += MissionSet[i].TDollContracts / TDollNeeded / MissionSet[i].TimeMins;
                }
                if (EquipmentNeeded > 0 && MissionSet[i].EquipmentContracts > 0)
                {
                    CraftValuePerMin += MissionSet[i].EquipmentContracts / EquipmentNeeded / MissionSet[i].TimeMins;
                }
                if (QuickProduceNeeded > 0 && MissionSet[i].QuickProduceContracts > 0)
                {
                    CraftValuePerMin += MissionSet[i].QuickProduceContracts / QuickProduceNeeded / MissionSet[i].TimeMins;
                }
                if (QuickRepairNeeded > 0 && MissionSet[i].QuickRepairContracts > 0)
                {
                    CraftValuePerMin += MissionSet[i].QuickRepairContracts / QuickRepairNeeded / MissionSet[i].TimeMins;
                }
                if (TokenNeeded > 0 && MissionSet[i].Tokens > 0)
                {
                    CraftValuePerMin += MissionSet[i].Tokens / TokenNeeded / MissionSet[i].TimeMins;
                }
            }

            return CraftValuePerMin;
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

        public void UpdateMissionDisplay()
        {
            CurrentValidMissionsListBox.Items.Clear();
            if (MissionList.Count > 0)
            {
                for (int i = 0; i < MissionList.Count; i++)
                {
                    CurrentValidMissionsListBox.Items.Add(MissionList[i]);
                }
            }
        }

        public int CompareMissionValuePerMin(MissionValuePerMin A,MissionValuePerMin B)
        {
            if (A.ValuePerMin < B.ValuePerMin)
            {
                return 1;
            }
            else if (A.ValuePerMin > B.ValuePerMin)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public int CompareMissionSetCraftsPerMin(MissionSetCraftsPerMin A,MissionSetCraftsPerMin B)
        {
            if(A.CraftsPerMin < B.CraftsPerMin)
            {
                return 1;
            }
            else if(A.CraftsPerMin > B.CraftsPerMin)
            {
                return -1;
            }
            else
            {
                //in case of a tie, use total resources/min
                if(A.CraftWeighedResourcesPerMin < B.CraftWeighedResourcesPerMin)
                {
                    return 1;
                }
                if(A.CraftWeighedResourcesPerMin > B.CraftWeighedResourcesPerMin)
                {
                    return -1;
                }

                return 0;
            }
        }

        private void OptimizeButton_Click(object sender, RoutedEventArgs e)
        {
            //check that all the input weights/craft amounts are valid numbers 
            try
            {
                if (Convert.ToDouble(ManpowerTextBox.Text) < 0 || Convert.ToDouble(AmmoTextBox.Text) < 0 || Convert.ToDouble(RationsTextBox.Text) < 0 || Convert.ToDouble(PartsTextBox.Text) < 0 || Convert.ToDouble(TDollTextBox.Text) < 0 || Convert.ToDouble(EquipTextBox.Text) < 0 || Convert.ToDouble(QuickProductionTextBox.Text) < 0 || Convert.ToDouble(QuickRepairTextBox.Text) < 0 || Convert.ToDouble(TokenTextBox.Text) < 0)
                {
                    MessageBox.Show("Weights/craft amounts must be >= 0");
                    return;
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Failed to parse input weights/craft amounts: " + Ex.Message);
                return;
            }

            //check that there greater than 4 missions allowed
            if(MissionList.Count > 4)
            {
                //optimize for resources/min
                if (OptimizationTypeComboBox.SelectedIndex == 0)
                {
                    //calculate the resource/min value for each mission
                    List<MissionValuePerMin> MissionValues = new List<MissionValuePerMin>();
                    for(int i = 0;i < MissionList.Count;i++)
                    {
                        MissionValuePerMin NewMissionValue = new MissionValuePerMin();
                        NewMissionValue.Mission = MissionList[i];
                        NewMissionValue.ValuePerMin = CalculateMissionValuePerMin(MissionList[i], Convert.ToDouble(ManpowerTextBox.Text), Convert.ToDouble(AmmoTextBox.Text), Convert.ToDouble(RationsTextBox.Text), Convert.ToDouble(PartsTextBox.Text), Convert.ToDouble(TDollTextBox.Text), Convert.ToDouble(EquipTextBox.Text), Convert.ToDouble(QuickProductionTextBox.Text), Convert.ToDouble(QuickRepairTextBox.Text), Convert.ToDouble(TokenTextBox.Text));
                        MissionValues.Add(NewMissionValue);
                    }

                    //sort the missions to find the best ones
                    MissionValues.Sort(CompareMissionValuePerMin);

                    //put the mission display in order
                    MissionList.Clear();
                    for(int i = 0;i < MissionValues.Count;i++)
                    {
                        MissionList.Add(MissionValues[i].Mission);
                    }
                    UpdateMissionDisplay();
                }
                //optimize for crafts/min
                if (OptimizationTypeComboBox.SelectedIndex == 1)
                {
                    //generate all possible mission combinations
                    var all_mission_sets = GetKCombs(MissionList, 4).ToList();

                    //calculate the number of crafts/min for each mission combination
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
                        NewMissionSet.CraftWeighedResourcesPerMin = CalculateCraftWeightedValuePerMin(all_mission_sets[i], Convert.ToDouble(ManpowerTextBox.Text), Convert.ToDouble(AmmoTextBox.Text), Convert.ToDouble(RationsTextBox.Text), Convert.ToDouble(PartsTextBox.Text), Convert.ToDouble(TDollTextBox.Text), Convert.ToDouble(EquipTextBox.Text), Convert.ToDouble(QuickProductionTextBox.Text), Convert.ToDouble(QuickRepairTextBox.Text), Convert.ToDouble(TokenTextBox.Text));
                        NewMissionSet.MissionSet = all_mission_sets[i];                       
                        MissionSets.Add(NewMissionSet);
                    }

                    //sort the mission combinations to find the best one
                    MissionSets.Sort(CompareMissionSetCraftsPerMin);

                    CalculateCraftsPerMin(MissionSets[0].MissionSet,500,500,500,500,0,0,0,0,0);
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
            //check that both the great success and base bonus are valid
            double GreatSuccessRate = 0;
            double BaseBonus = 0;
            try
            {
                GreatSuccessRate = Convert.ToDouble(GreatSuccessTextBox.Text)/100;
                BaseBonus = Convert.ToDouble(BaseBonusTextBox.Text) / 100;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Great Success Chance or Base Bonus are invalid: " + Ex.Message);
                return;
            }

            CurrentValidMissionsListBox.Items.Clear();
            LoadMissionData(@"..\..\..\..\Logistics Data.csv", GreatSuccessRate, BaseBonus);
            UpdateMissionDisplay();
        }

        private void ApplyTimeContraintsButton_Click(object sender, RoutedEventArgs e)
        {
            int LowerLimitMins = 0;
            bool UseLowerLimit = false;
            int UpperLimitMins = 0;
            bool UseUpperLimit = false;

            //check that at least one textbox has something in it
            if(string.IsNullOrWhiteSpace(LowerLimitTextBox.Text) == true && string.IsNullOrWhiteSpace(UpperLimitTextBox.Text) == true)
            {
                MessageBox.Show("Please enter a valid value in one of the time limit boxs");
                return;
            }
            //check that none of the textboxes has a non number in it
            if(string.IsNullOrWhiteSpace(LowerLimitTextBox.Text) == false)
            {
                UseLowerLimit = true;
                try
                {
                    LowerLimitMins = Convert.ToInt32(Math.Round(Convert.ToDouble(LowerLimitTextBox.Text)*60));
                }
                catch(Exception Ex)
                {
                    MessageBox.Show("Lower limit invalid: " + Ex.Message);
                    return;
                }
            }
            if(string.IsNullOrWhiteSpace(UpperLimitTextBox.Text) == false)
            {
                UseUpperLimit = true;
                try
                {
                    UpperLimitMins = Convert.ToInt32(Math.Round(Convert.ToDouble(UpperLimitTextBox.Text)*60));
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Upper limit invalid: " + Ex.Message);
                    return;
                }
            }

            //apply the specified limits to the loaded missions
            if(UseLowerLimit == true && UseUpperLimit == false)
            {
                for(int i = MissionList.Count - 1;i >= 0;i--)
                {
                    if(MissionList[i].TimeMins >= LowerLimitMins)
                    {
                        MissionList.RemoveAt(i);
                    }
                }
            }
            if(UseLowerLimit == false && UseUpperLimit == true)
            {
                for (int i = MissionList.Count - 1; i >= 0; i--)
                {
                    if (MissionList[i].TimeMins <= UpperLimitMins)
                    {
                        MissionList.RemoveAt(i);
                    }
                }
            }
            if(UseLowerLimit == true && UseUpperLimit == true)
            {
                //check that the upper limit is greater than the limit limit
                if(UpperLimitMins <= LowerLimitMins)
                {
                    MessageBox.Show("Upper limit must be greater than the lower limit");
                    return;
                }
                for (int i = MissionList.Count - 1; i >= 0; i--)
                {
                    if (MissionList[i].TimeMins >= LowerLimitMins && MissionList[i].TimeMins <= UpperLimitMins)
                    {
                        MissionList.RemoveAt(i);
                    }
                }
            }

            //update the mission list UI
            UpdateMissionDisplay();
        }
    }
}
