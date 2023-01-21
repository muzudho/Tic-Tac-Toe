namespace Assets.Scripts
{
    using System.Text.RegularExpressions;

    internal static class StaticHelper
    {
        static Regex RegexSquareN { get; } = new(@"^Square (\d+)", RegexOptions.Compiled);

        /// <summary>
        /// マス番号取得
        /// 
        /// - "Square 0" の "0" の部分を整数型で返す
        /// - 必ず成功するものとして、チェックを省く
        /// </summary>
        /// <param name="nameOfSquareGameObject"></param>
        /// <returns></returns>
        public static int GetSquareByName(string nameOfSquareGameObject)
        {
            return int.Parse(RegexSquareN.Match(nameOfSquareGameObject).Groups[1].Value);
        }
    }
}
