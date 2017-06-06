using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageStore.Models
{
    public class RelalSeller
    {
        public string SellerName { get; set; }
        public int ProdutoCount { get; set; }
        public int QuestCount { get; set; }
        public int AnswerCount { get; set; }
        public int ProdSellCount { get; set; }
        public decimal ValProdOfert { get; set; }
        public decimal ValProdSell { get; set; }
        public double Reput { get; set; }
        public int DoaCount { get; set; }
    }

  /*  public class RelGeral
    {
        public int UserCount { get; set; }
        public int SProdutoCount { get; set; }
        public int SQuestCount { get; set; }
        public int SAnswerCount { get; set; }
        public int SProdSellCount { get; set; }
        public double SValProdOfert { get; set; }
        public double SValProdSell { get; set; }
        public double ReputMed { get; set; }
        public int SDoaCount { get; set; }
    }*/


}