using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Neutral, // special case at the start of the game
    Rock,
    Paper,
    Scissor
}

public class Element
{
    public Type type;

    public Element(Type type_)
    {
        this.type = type_;
    }

    public static bool operator >(Element a, Element b)
    {
        switch (a.type)
        {
            case Type.Neutral:
                return true;
            case Type.Rock:
                return b.type == Type.Scissor;
            case Type.Paper:
                return b.type == Type.Rock;
            case Type.Scissor:
                return b.type == Type.Paper;
            
            default:
                return true;
        }
    }

    public static bool operator <(Element a, Element b)
    {
        switch (a.type)
        {
            case Type.Neutral:
                return false;
            case Type.Rock:
                return b.type == Type.Paper;
            case Type.Paper:
                return b.type == Type.Scissor;
            case Type.Scissor:
                return b.type == Type.Rock;
            default:
                return false;
        }
    }
}
