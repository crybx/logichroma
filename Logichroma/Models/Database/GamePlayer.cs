//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logichroma.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class GamePlayer
    {
        public int GameId { get; set; }
        public string PlayerId { get; set; }
        public Nullable<int> PlayerNumber { get; set; }
        public string Nickname { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Game Game { get; set; }
    }
}
