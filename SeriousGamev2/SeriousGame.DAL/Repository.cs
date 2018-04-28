using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGame.DAL
{
    public class Repository
    {
        teamtimEntities _context;

        public Repository()
        {
            _context = new teamtimEntities();
            _context.Database.Log = (message) => Debug.WriteLine(message);
            _context.Configuration.ProxyCreationEnabled = true;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public int AddIdEquipe(int idJeu)
        {
            _context.EQUIPEs.Add(new EQUIPE() { ID_JEU = idJeu});
            return  _context.SaveChanges(); 
        }

        public int GetIdEquipe(int idJeu)
        {
            return _context.EQUIPEs.Select(eq => eq.ID_JEU == idJeu).Count();
        }

        public int createPlayer(string nom, string prenom, int idEquipe)
        {
            _context.JOUEURs.Add(new JOUEUR() { NOM = nom, PRENOM = prenom,ID_EQUIPE=idEquipe });
            _context.SaveChanges();

            var result = _context.JOUEURs.Max(je => je.ID);
            return result;
        }
        public int addPhoto(int idPlayer, string filename)
        {

            JOUEUR j = (JOUEUR)(_context.JOUEURs.FirstOrDefault(joueur => joueur.ID == idPlayer));
            j.PHOTO = "ftp://51.144.166.162/profil/" + filename +"_"+ idPlayer+".png";
            return _context.SaveChanges();
        }

        public int getIdJeu(string code)
        {
            return ((JEU)(_context.JEUs.FirstOrDefault(jeu => jeu.CODE == code))).ID;
        }

        public List<ETAPE> getEtapes(int idJeu)
        {
            List<ETAPE> etapes = new List<ETAPE>();
            etapes = _context.ETAPEs.Where(etape => etape.ID_JEU == idJeu).ToList();
            return etapes;
        }
        public QUIZZ getQuiz(int idEpreuve)
        {
            QUIZZ quizz;
            quizz = _context.QUIZZs.FirstOrDefault(q => q.ID == idEpreuve);
            return quizz;
        }
    }
}
