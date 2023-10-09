using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048alt
{
    public partial class Normal : Form
    {
        // コマの通番
        int id = 1;

        // コマのリスト
        List<Piece> pieces = new List<Piece>();

        // 全マス
        List<(int, int)> allLocation = new List<(int, int)>()
        {
            (58, 176), (130, 176), (202, 176), (274, 176),
            (58, 248), (130, 248), (202, 248), (274, 248),
            (58, 320), (130, 320), (202, 320), (274, 320),
            (58, 392), (130, 392), (202, 392), (274, 392)
        };

        public Normal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面表示時処理
        /// </summary>
        private void Normal_Load(object sender, EventArgs e)
        {
            //最初のマスの追加
            Label firstPieceLabel = new Label();
            Controls.Add(firstPieceLabel);
            Piece firstPiece = new Piece(firstPieceLabel, (58, 176), 1);
            firstPiece.label.Show();
            pieces.Add(firstPiece);

            //通番のインクリメント
            id++;

            //ハイスコアの表示
            HighScore.Text = "HighScore： 2";
        }

        /// <summary>
        /// 画面非表示時処理
        /// </summary>
        private void Normal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //メニュー画面の表示
            Owner.Show();
        }

        /// <summary>
        /// ボタン押下時処理
        /// </summary>
        private void Normal_KeyDown(object sender, KeyEventArgs e)
        {
            //移動後のマスのリスト
            List<(int, int)> pieceLocations = new List<(int, int)>();

            //消去するマスのリスト
            List<Piece> removePieces = new List<Piece>();

            switch (e.KeyCode)
            {
                //矢印キーが押されたことを表示する
                case Keys.Up:
                    pieces = pieces.OrderBy(a => a.label.Location.Y).ToList();
                    foreach(Piece piece in pieces)
                    {
                        piece.MoveUp(pieces);
                        pieceLocations.Add((piece.label.Location.X, piece.label.Location.Y));

                        //マスが覆われているかチェック
                        bool isCover = CheckCover(piece);
                        if (isCover)
                        {
                            //覆われているマスの消去
                            RemovePiece(piece, removePieces);
                        }
                    }
                    //新規マスの追加
                    AddPieces(pieceLocations);
                    break;                
                case Keys.Down:
                    pieces = pieces.OrderBy(a => -a.label.Location.Y).ToList();
                    foreach (Piece piece in pieces)
                    {
                        piece.MoveDown(pieces);
                        pieceLocations.Add((piece.label.Location.X, piece.label.Location.Y));

                        //マスが覆われているかチェック
                        bool isCover = CheckCover(piece);
                        if (isCover)
                        {
                            //覆われているマスの消去
                            RemovePiece(piece, removePieces);
                        }
                    }
                    //新規マスの追加
                    AddPieces(pieceLocations);
                    break;
                case Keys.Left:
                    pieces = pieces.OrderBy(a => a.label.Location.X).ToList();
                    foreach (Piece piece in pieces)
                    {
                        piece.MoveLeft(pieces);
                        pieceLocations.Add((piece.label.Location.X, piece.label.Location.Y));

                        //マスが覆われているかチェック
                        bool isCover = CheckCover(piece);
                        if (isCover)
                        {
                            //覆われているマスの消去
                            RemovePiece(piece, removePieces);
                        }
                    }
                    //新規マスの追加
                    AddPieces(pieceLocations);
                    break;
                case Keys.Right:
                    pieces = pieces.OrderBy(a => -a.label.Location.X).ToList();
                    foreach (Piece piece in pieces)
                    {
                        piece.MoveRight(pieces);
                        pieceLocations.Add((piece.label.Location.X, piece.label.Location.Y));

                        //マスが覆われているかチェック
                        bool isCover = CheckCover(piece);
                        if (isCover)
                        {
                            //覆われているマスの消去
                            RemovePiece(piece, removePieces);
                        }
                    }
                    //新規マスの追加
                    AddPieces(pieceLocations);
                    break;
            }

            //統合されたマスを消去
            pieces = pieces.Except(removePieces).ToList();
            //ハイスコアの更新
            UpdateHighScore();
        }

        /// <summary>
        /// マスの追加
        /// </summary>
        /// <param name=""></param>
        private void AddPieces(List<(int, int)> pieceLocations)
        {
            //空きマスの算出
            List<(int, int)> spaces = allLocation.Except(pieceLocations).ToList();
            
            if (spaces.Count != 0)
            {
                //空きマスが0でない場合

                //空きマスをランダムで1つ選択
                Random rnd = new Random();
                int randIndex = rnd.Next(spaces.Count);

                //マスの追加
                Label pieceLabel = new Label();
                Controls.Add(pieceLabel);
                Piece piece = new Piece(pieceLabel, (spaces[randIndex].Item1, spaces[randIndex].Item2), id);
                piece.label.Show();
                pieces.Add(piece);

                //通番のインクリメント
                id++;
            } 
        }

        /// <summary>
        /// マスのチェック
        /// </summary>
        /// <param name=""></param>
        public bool CheckCover(Piece piece)
        {
            if (piece.isCover)
            {
                //他のマスと被っている場合、被り先のマスの数字を増やす
                Piece coverPiece = piece.coverPiece;
                if (coverPiece != null)
                {
                    int afterNumber = coverPiece.number * 2;
                    coverPiece.UpdateNumber(afterNumber);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// マスの消去
        /// </summary>
        /// <param name="piece">マス</param>
        /// <param name="removePieces">消去するマスのリスト</param>
        public void RemovePiece(Piece piece, List<Piece> removePieces)
        {
            removePieces.Add(piece);
            piece.label.Hide();
            piece.label.Dispose();
            Controls.Remove(piece.label);
        }

        /// <summary>
        /// ハイスコアの更新
        /// </summary>
        public void UpdateHighScore()
        {
            //数字でマスをソート
            pieces = pieces.OrderBy(a => -a.number).ToList();

            //一番大きい数字を表示
            HighScore.Text = "HighScore： " + pieces[0].number.ToString();
        }

        /// <summary>
        /// リセットボタン押下
        /// </summary>
        private void label2_Click(object sender, EventArgs e)
        {
            //既存のマスの消去
            foreach (Piece piece in pieces)
            {
                piece.label.Hide();
                piece.label.Dispose();
                Controls.Remove(piece.label);
            }
            pieces = new List<Piece>();

            //最初のマスの追加
            Label firstPieceLabel = new Label();
            Controls.Add(firstPieceLabel);
            Piece firstPiece = new Piece(firstPieceLabel, (58, 176), 1);
            firstPiece.label.Show();
            pieces.Add(firstPiece);

            //通番のインクリメント
            id++;

            //ハイスコアの表示
            HighScore.Text = "HighScore： 2";
        }
    }
}
