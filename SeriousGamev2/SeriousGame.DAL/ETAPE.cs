//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeriousGame.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ETAPE
    {
        public int ID { get; set; }
        public string NOM { get; set; }
        public string TYPE { get; set; }
        public Nullable<int> ID_JEU { get; set; }
        public Nullable<int> ID_EPREUVE { get; set; }
    }
}
