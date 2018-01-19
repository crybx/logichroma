
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Logichroma.Database
{

using System;
    using System.Collections.Generic;
    
public partial class GamePlayer
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public GamePlayer()
    {

        this.GameCards = new HashSet<GameCard>();

    }


    public int GamePlayerId { get; set; }

    public int GameId { get; set; }

    public string PlayerId { get; set; }

    public Nullable<int> PlayerNumber { get; set; }

    public string Nickname { get; set; }

    public bool IsGameOwner { get; set; }



    public virtual AspNetUser AspNetUser { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GameCard> GameCards { get; set; }

    public virtual Game Game { get; set; }

}

}
