//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Jogo
    {
        public Jogo()
        {
            this.Jogada = new HashSet<Jogada>();
        }
    
        public int idJogo { get; set; }
        public Nullable<int> idUser1 { get; set; }
        public Nullable<int> idUser2 { get; set; }
        public Nullable<int> vencedor { get; set; }
        public Nullable<int> ModoJogo { get; set; }
    
        public virtual ICollection<Jogada> Jogada { get; set; }
        public virtual Player Player { get; set; }
        public virtual Player Player1 { get; set; }
    }
}
