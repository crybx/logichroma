
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
    
public partial class GameCard
{

    public int GameId { get; set; }

    public int Order { get; set; }

    public int CardSuitId { get; set; }

    public int CardValueId { get; set; }

    public string CardState { get; set; }

    public Nullable<int> GamePlayerId { get; set; }

    public bool IsSuitRevealed { get; set; }

    public bool IsValueRevealed { get; set; }

    public Nullable<int> DiscardOrder { get; set; }



    public virtual CardSuit CardSuit { get; set; }

    public virtual CardValue CardValue { get; set; }

    public virtual GamePlayer GamePlayer { get; set; }

    public virtual Game Game { get; set; }

}

}
