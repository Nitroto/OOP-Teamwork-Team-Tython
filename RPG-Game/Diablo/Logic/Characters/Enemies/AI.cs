using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diablo.Logic.Characters.Enemies
{
    public class AI
    {
        //public Vector2 currentTargetSquare;
        //private Vector2 getNewTargetSquare()
        //{
        //    List<Vector2> path = PathFinder.FindPath(
        //        TileMap.GetSquareAtPixel(EnemyBase.WorldCenter),
        //        TileMap.GetSquareAtPixel(Player.BaseSprite.WorldCenter));

        //    if (path.Count > 1)
        //    {
        //        return new Vector2(path[1].X, path[1].Y);
        //    }
        //    else
        //    {
        //        return TileMap.GetSquareAtPixel(
        //            Player.BaseSprite.WorldCenter);
        //    }
        //}
        //private Vector2 determineMoveDirection()
        //{
        //    if (reachedTargetSquare())
        //    {
        //        currentTargetSquare = getNewTargetSquare();
        //    }

        //    Vector2 squareCenter = TileMap.GetSquareCenter(
        //        currentTargetSquare);

        //    return squareCenter - EnemyBase.WorldCenter;
        //}

        //private bool reachedTargetSquare()
        //{
        //    return (
        //        Vector2.Distance(
        //            EnemyBase.WorldCenter,
        //            TileMap.GetSquareCenter(currentTargetSquare))
        //        <= 2);
        //}
    }
}
