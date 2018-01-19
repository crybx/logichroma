
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
    
public partial class Game
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Game()
    {

        this.GameCards = new HashSet<GameCard>();

        this.GameStatuses = new HashSet<GameStatus>();

        this.GamePlayers = new HashSet<GamePlayer>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public int DifficultyLvl { get; set; }

    public int NextCard { get; set; }

    public System.DateTime StartDateTime { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GameCard> GameCards { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GameStatus> GameStatuses { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GamePlayer> GamePlayers { get; set; }

}

}
