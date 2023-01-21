namespace Assets.Scripts
{
    /// <summary>
    /// 入力の受入／拒否を判定
    /// </summary>
    internal static class StaticValidator
    {
        /// <summary>
        /// そのマスに駒を置けるか？
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="square"></param>
        /// <returns></returns>
        public static bool ValidateMove(Position pos, int square)
        {
            return pos.GetPiece(square) == Pieces.None;
        }
    }
}
