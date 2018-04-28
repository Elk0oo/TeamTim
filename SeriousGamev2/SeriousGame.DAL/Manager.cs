using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGame.DAL
{
   public class Manager
    {
        public EQUIPE uneEquipe { get; set; }

        public string codeJeu { get; set; }

        public List<JOUEUR> lstJoueurs;
        public Manager()
        {
            lstJoueurs = new List<JOUEUR>();
        }
    }
}
