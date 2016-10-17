using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinningTheTournament
{
    class Tournament
    {
        static void Main(string[] args)
        {

            //string[] test = { "1", "2", "3", "4", "5", "6", "7", "8" };
            string[] test = { "1", "2", "3", "4" };
            Tournament bla = new Tournament(test);
            //bla.calculateAllPs();
            //bla.readCompetitors(test);
            //double testResult = bla.calculateP("A", bla.competitors);
            Console.ReadLine();
        }

        

        public Tournament(string[] skills)
        {
            this.noOfCompetitors = skills.Length;
            this.noOfRounds = (int) Math.Log(this.noOfCompetitors, 2);
            this.competitors = new Dictionary<string, double[]>();
            this.readCompetitors(skills);
        }

        private Dictionary<string, double[]> competitors;
        private int noOfCompetitors;
        private int noOfRounds;

        private void readCompetitors(string[] newCompetitors)
        {
            char competitorName = 'A';
            foreach (string competitor in newCompetitors)
            {
                double[] newPSet = new double[this.noOfRounds + 1];
                newPSet[0] = Double.Parse(competitor);
                this.competitors.Add(competitorName.ToString(), newPSet);
                competitorName++;
            }
        }

        private double calculateP(string competitorName, Dictionary<string, double[]> allCompetitors)
        {
            //first round win P:
            double firstRoundP = 0;
            double[] competitorP;
            allCompetitors.TryGetValue(competitorName, out competitorP);
            if (competitorP[0] != null)
            {
                var otherCompetitors = from competitor in allCompetitors where competitor.Key != competitorName select competitor;
                double multiplier = (double)1 / otherCompetitors.Count();
                foreach (var competitor in otherCompetitors)
                {
                    firstRoundP += multiplier * competitorP[0] / (competitorP[0] + competitor.Value[0]);
                }
            }
            return firstRoundP;
        }
        

        private void WRONGcalculateAllPs()
        {
            for (int i = 1; i <= noOfRounds; i++)
            {
                foreach (var competitor in this.competitors)
                {
                    double P = 0;
                    var otherCompetitors = from otherCompetitor in this.competitors where otherCompetitor.Key != competitor.Key select otherCompetitor;
                    double multiplier = (double) 1 / (this.noOfCompetitors / Math.Pow(2, i - 1) - 1);
                    foreach (var otherCompetitor in otherCompetitors)
                    {
                        if (i == 1)
                        {
                            P+= multiplier * competitor.Value[0] / (competitor.Value[0] + otherCompetitor.Value[0]);
                        }
                        else
                        {
                            P+= competitor.Value[i-1] * multiplier * otherCompetitor.Value[i - 1] * competitor.Value[0] / (competitor.Value[0] + otherCompetitor.Value[0]);
                        }
                    }
                    competitor.Value[i] = P;
                }
            }
            
        }

        private void calculateAllPs()
        {
            int noOfRuns = 1000000;
            for (int i = 0; i < noOfRuns; i++)
            {

            }
        }

    }
}
