﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHL_BL.Entities
{
    public class csBet
    {
        private long Id_BI { get; set; }
        
        public string Player { get; set; }         
        public double WinAmount { get; set; }
        public double RiskAmount { get; set; }      
        public string Result { get; set; }
        public Nullable<Double> Net { get; set; }     
        public string WagerPlay { get; set; }
        public string IdSport { get; set; }       
        public System.DateTime PlacedDate { get; set; }
        public int Odds { get; set; }
        public double Points { get; set; }
        public int Rot { get; set; }
        private string Score { get; set; }
  
        private string BeatLine { get; set; }

        public int IdWager { get; set; }
        public int IdWagerDetail { get; set; }
        public Nullable<int> IdAgent { get; set; }
        public string Agent { get; set; }
        public Nullable<int> IdPlayer { get; set; }
        public int IdLineType { get; set; }
        public string LineTypeName { get; set; }
        public string LoginName { get; set; }
        public string GamePeriod { get; set; }
        public string League { get; set; }
        public string CompleteDescription { get; set; }
        public string DetailDescription { get; set; }
        public string Team { get; set; }
        public int IdGame { get; set; }
        public int IdLeague { get; set; }
        public Nullable<int> Period { get; set; }
        public string FAV_DOG { get; set; }
        public int Play { get; set; }
        public System.DateTime SettledDate { get; set; }
        public string IP { get; set; }
        public int VisitorScore { get; set; }
        public int HomeScore { get; set; }
        public string OverUnder = "";


        public double? CrisPoints { get; set; }
        public int? CrisJuice { get; set; }


        public double? PinniPoints { get; set; }
        public int? PinniJuice { get; set; }


        public double? OurPoints { get; set; }
        public int? OurJuice { get; set; }
        //public int? ML { get; set; }

        public string VisHome { get; set; }


        public csBet(long id_BI, int idWager, int idWagerDetail, int? idAgent, string agent, int? idPlayer, string player, int idLineType, string lineTypeName, string loginName, double winAmount, double riskAmount, string result, double? net, string gamePeriod, string league, string completeDescription, string detailDescription, string team, int idGame, int idLeague, int? period, string fAV_DOG, int play, string wagerPlay, string idSport, DateTime settledDate, DateTime placedDate, int odds, double points, string score, string iP, string beatLine)
        {
            Id_BI = id_BI;
            IdWager = idWager;
            IdWagerDetail = idWagerDetail;
            try { IdAgent = idAgent; } catch (Exception) { idAgent = null; }
            Agent = agent;
            try { IdPlayer = idPlayer; } catch (Exception) { IdPlayer = null; }
            Player = player;
            IdLineType = idLineType;
            LineTypeName = lineTypeName;
            LoginName = loginName;
            WinAmount = winAmount;
            RiskAmount = riskAmount;
            Result = result;
            Net = net;
            GamePeriod = CastGamePeriod(gamePeriod);
            League = league;
            CompleteDescription = completeDescription;
            DetailDescription = detailDescription;
            Team = team;
            IdGame = idGame;
            IdLeague = idLeague;
            Period = period;
            FAV_DOG = fAV_DOG;
            Play = play;
            WagerPlay = WagerType(wagerPlay);
            IdSport = idSport;
            SettledDate = settledDate;
            PlacedDate = placedDate;
            Odds = odds;
            Points = points;
            Score = score;
            IP = iP;
            BeatLine = beatLine;
            Rot = CastRotation(detailDescription);
            CastScores(score);
        }

        public csBet() { }


        private string WagerType(string txt)
        {

            VisHome = (txt.ToUpper().Contains("HOME")) ? "H" : "V";

            if (txt.ToUpper().Contains("MONEY")) return "ML";
            else if (txt.ToUpper().Contains("SPREAD")) return "SP";
            else if (txt.ToUpper().Contains("DRAW")) return "DR";
            else if (txt.ToUpper().Contains("TOTAL")) return "TOT";
            return txt;
        }


        private int CastRotation(string d)
        {
            var detail = d.Split(']');
            detail[0] = detail[0].ToString().Trim('[');

            if(this.WagerPlay == "TOT")
            {
                this.OverUnder = (d.Contains("TOTAL u")) ? "u" : OverUnder = "o";
            }



            return Convert.ToInt32(detail[0]);
        }


        private void CastScores(string score)
        {
            var scores = score.Split('-');

            this.VisitorScore = Convert.ToInt32(scores[0]);
            this.HomeScore = Convert.ToInt32(scores[1]);
        }


        private string CastGamePeriod(string gp)
        {
            string gameP = "";

            if (gp.ToUpper().Contains("GAME"))gameP = "FG";
            else if (gp.ToUpper().Contains("FIRST HALF"))gameP = "1H";
            else if (gp.ToUpper().Contains("SECOND HALF")) gameP = "2H";
            else if (gp.ToUpper().Contains("FIRST QUARTER")) gameP = "1Q";
            else if (gp.ToUpper().Contains("SECOND QUARTER"))gameP = "2Q";
            else if (gp.ToUpper().Contains("THIRD  QUARTER"))gameP = "3Q";
            else if (gp.ToUpper().Contains("FOURTH QUARTER"))gameP = "4Q";
            else if (gp.ToUpper().Contains("FIRST PERIOD"))gameP = "1P";
            else if (gp.ToUpper().Contains("SECOND PERIOD"))gameP = "2P";
            else if (gp.ToUpper().Contains("THIRD PERIOD"))gameP = "3P";

            return gameP;
        }

    }
}
