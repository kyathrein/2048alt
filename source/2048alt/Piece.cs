using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _2048alt
{
    public class Piece
    {
        //通番
        public int id;

        // ラベル
        public Label label;
        // 数字(÷2マスのときは-1とする)
        public int number;

        // 他のマスと被っているか否か
        public bool isCover = false;
        // 被っているマス
        public Piece coverPiece = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="label">ラベル</param>
        /// <param name="coordinate">位置の座標</param>
        public Piece(Label label, (int x, int y)coordinate, int id)
        {
            //通番
            this.id = id;

            //ラベル
            this.label = label;
            //ラベルの設定
            this.label.Size = new Size(52, 52);
            this.label.Location = new Point(coordinate.x, coordinate.y);
            this.label.BorderStyle = BorderStyle.FixedSingle;
            this.label.BackColor = Color.White;
            this.label.BringToFront();
            this.label.TextAlign = ContentAlignment.MiddleCenter;
            this.label.Font = new Font(FontFamily.GenericMonospace, 10);

            // 数字
            number = 2;
            // ラベルの数字
            this.label.Text = number.ToString();

            // id
            this.id = id;
        }

        /// <summary>
        /// 上への移動
        /// </summary>
        /// <param name="pieces">マス一覧</param>
        public void MoveUp(List<Piece> pieces)
        {
            //リセット
            isCover = false;

            Move(pieces, (0, -72));
        }

        /// <summary>
        /// 下への移動
        /// </summary>
        /// <param name="pieces">マス一覧</param>
        public void MoveDown(List<Piece> pieces)
        {
            //リセット
            isCover = false;

            Move(pieces, (0, 72));

        }

        /// <summary>
        /// 左への移動
        /// </summary>
        /// <param name="pieces">マス一覧</param>
        public void MoveLeft(List<Piece> pieces)
        {
            //リセット
            isCover = false;

            Move(pieces, (-72, 0));
        }

        /// <summary>
        /// 右への移動
        /// </summary>
        /// <param name="pieces">マス一覧</param>
        public void MoveRight(List<Piece> pieces)
        {
            //リセット
            isCover = false;

            Move(pieces, (72, 0));
        }

        /// <summary>
        /// 移動
        /// </summary>
        /// <param name="pieces">マス一覧</param>
        /// <param name="displacement">変位</param>
        public void Move(List<Piece> pieces, (int x, int y) displacement)
        {
            //リセット
            isCover = false;

            bool canMove = CanMove(pieces, (label.Location.X + displacement.x, label.Location.Y + displacement.y));

            while (canMove)
            {
                label.Location = new Point(label.Location.X + displacement.x, label.Location.Y + displacement.y);

                canMove = CanMove(pieces, (label.Location.X + displacement.x, label.Location.Y + displacement.y));
            }
        }

        /// <summary>
        /// 移動できるかのチェック
        /// </summary>
        /// <param name="pieces">マス一覧</param>
        /// <param name="afterLocation">移動後の座標</param>
        public bool CanMove(List<Piece> pieces, (int x, int y) afterLocation)
        {
            //数字が同じ他のマスと被っているか否かのチェック
            Piece piece = pieces.Find(a =>
            (a.label.Location.X == this.label.Location.X) && (a.label.Location.Y == this.label.Location.Y)
             && ((a.number == this.number) || (a.number == -1) || (this.number == -1)) && (a.id != this.id));
            if (piece != null)
            {
                isCover = true;
                coverPiece = piece;
                return false;
            }

            //数字が異なる他のマスとぶつかるか否かのチェック
            //÷2マスの場合はぶつからない
            Piece piece2 = pieces.Find(a =>
            (a.label.Location.X == afterLocation.x) && (a.label.Location.Y == afterLocation.y)
             && ((a.number != this.number) && (a.number != -1) && (this.number != -1))
             && (a.id != this.id));
            if (piece2 != null)
            {
                return false;
            }

            //端か否かのチェック
            if (afterLocation.x < 50 || afterLocation.x > 338
                || afterLocation.y < 170 || afterLocation.y > 458)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数字の更新
        /// </summary>
        /// <param name="afterNumber">更新後の数字</param>
        public void UpdateNumber(int afterNumber)
        {
            // 数字
            this.number = afterNumber;
            // ラベルの数字
            if (number == -1)
            {
                //÷2マスの場合、"÷2"と表示
                this.label.Text = "÷2";
            }
            else
            {
                this.label.Text = number.ToString();
            }
        }
    }
}
