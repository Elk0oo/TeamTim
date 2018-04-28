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

        public int createPlayer(string nom,string prenom)
        {
            _context.JOUEURs.Add(new JOUEUR() { NOM= nom, PRENOM= prenom });
            _context.SaveChanges();
            
            var result = _context.JOUEURs.Max(je => je.ID);
            return result;
        }
        public int addPhoto(int idPlayer,string filename)
        {

            JOUEUR j = (JOUEUR)(_context.JOUEURs.FirstOrDefault(joueur => joueur.ID == idPlayer));
            j.PHOTO = "ftp://51.144.166.162/profil/"+filename+".png";
            return _context.SaveChanges();
        }

        public string getCodeJeu()
        {
            return _context.JEU.FirstOrDefault(jeu => jeu.CODE).ToString();
        }
    }
}
