using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//REMEMBER SET "Embed Interop Types = False" for "Microsoft.Office.Core" and "Microsoft.Office.Interop.Word" dll
namespace Common
{
    public static class WordHelpers
    {
        private static Microsoft.Office.Interop.Word.ApplicationClass oWordApplic = new Microsoft.Office.Interop.Word.ApplicationClass();	// a reference to Word application
        private static Microsoft.Office.Interop.Word.Document oDoc;					// a reference to the document

        // Open a file (the file must exists) and activate it
        public static void Open(string strFileName)
        {
            object fileName = strFileName;
            object readOnly = false;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;

            oDoc = oWordApplic.Documents.Open(ref fileName, ref missing, ref readOnly,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing);

            //String read = string.Empty;
            //List<string> data = new List<string>();
            //for (int i = 0; i < oDoc.Paragraphs.Count; i++)
            //{
            //    string temp = oDoc.Paragraphs[i + 1].Range.Text.Trim();
            //    if (temp != string.Empty)
            //        data.Add(temp);
            //}
            //((_Document)oDoc).Close();
            //((_Application)oWordApplic).Quit();
            //return data;

            //GridView1.DataSource = data;
            //GridView1.DataBind();

            oDoc.Activate();
            //((_Document)oDoc).Close();
            //((_Application)oWordApplic).Quit();
        }

        // Open a new document
        public static void Open()
        {
            object missing = System.Reflection.Missing.Value;
            oDoc = oWordApplic.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            oDoc.Activate();
        }

        public static void Quit()
        {
            object missing = System.Reflection.Missing.Value;
            oWordApplic.Application.Quit(ref missing, ref missing, ref missing);
        }

        public static void Save()
        {
            oDoc.Save();
        }

        public static void SaveAs(string strFileName)
        {
            object missing = System.Reflection.Missing.Value;
            object fileName = strFileName;

            oDoc.SaveAs(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
        }

        // Save the document in HTML format
        public static void SaveAsHtml(string strFileName)
        {
            object missing = System.Reflection.Missing.Value;
            object fileName = strFileName;
            object Format = (int)Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;
            oDoc.SaveAs(ref fileName, ref Format, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
        }

        public static void InsertText(string strText)
        {
            oWordApplic.Selection.TypeText(strText);
        }

        public static void InsertLineBreak()
        {
            oWordApplic.Selection.TypeParagraph();
        }
        public static void InsertLineBreak(int nline)
        {
            for (int i = 0; i < nline; i++)
                oWordApplic.Selection.TypeParagraph();
        }

        // Change the paragraph alignement
        public static void SetAlignment(string strType)
        {
            switch (strType)
            {
                case "Center":
                    oWordApplic.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                case "Left":
                    oWordApplic.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    break;
                case "Right":
                    oWordApplic.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    break;
                case "Justify":
                    oWordApplic.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    break;
            }

        }

        // if you use thif function to change the font you should call it again with 
        // no parameter in order to set the font without a particular format
        public static void SetFont(string strType)
        {
            switch (strType)
            {
                case "Bold":
                    oWordApplic.Selection.Font.Bold = 1;
                    break;
                case "Italic":
                    oWordApplic.Selection.Font.Italic = 1;
                    break;
                case "Underlined":
                    oWordApplic.Selection.Font.Subscript = 0;
                    break;
            }

        }

        // disable all the style 
        public static void SetFont()
        {
            oWordApplic.Selection.Font.Bold = 0;
            oWordApplic.Selection.Font.Italic = 0;
            oWordApplic.Selection.Font.Subscript = 0;

        }

        public static void SetFontName(string strType)
        {
            oWordApplic.Selection.Font.Name = strType;

        }

        public static void SetFontSize(int nSize)
        {
            oWordApplic.Selection.Font.Size = nSize;

        }

        public static void InsertPagebreak()
        {
            // VB : Selection.InsertBreak Type:=wdPageBreak
            object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
            oWordApplic.Selection.InsertBreak(ref pBreak);
        }

        // Go to a predefined bookmark, if the bookmark doesn't exists the application will raise an error
        public static void GotoBookMark(string strBookMarkName)
        {
            // VB :  Selection.GoTo What:=wdGoToBookmark, Name:="nome"
            object missing = System.Reflection.Missing.Value;

            object Bookmark = (int)Microsoft.Office.Interop.Word.WdGoToItem.wdGoToBookmark;
            object NameBookMark = strBookMarkName;
            oWordApplic.Selection.GoTo(ref Bookmark, ref missing, ref missing, ref NameBookMark);
        }

        public static void GoToTheEnd()
        {
            // VB :  Selection.EndKey Unit:=wdStory
            object missing = System.Reflection.Missing.Value;
            object unit;
            unit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            oWordApplic.Selection.EndKey(ref unit, ref missing);

        }

        public static void GoToTheBeginning()
        {
            // VB : Selection.HomeKey Unit:=wdStory
            object missing = System.Reflection.Missing.Value;
            object unit;
            unit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            oWordApplic.Selection.HomeKey(ref unit, ref missing);

        }

        public static void GoToTheTable(int ntable)
        {
            //	Selection.GoTo What:=wdGoToTable, Which:=wdGoToFirst, Count:=1, Name:=""
            //    Selection.Find.ClearFormatting
            //    With Selection.Find
            //        .Text = ""
            //        .Replacement.Text = ""
            //        .Forward = True
            //        .Wrap = wdFindContinue
            //        .Format = False
            //        .MatchCase = False
            //        .MatchWholeWord = False
            //        .MatchWildcards = False
            //        .MatchSoundsLike = False
            //        .MatchAllWordForms = False
            //    End With

            object missing = System.Reflection.Missing.Value;
            object what;
            what = Microsoft.Office.Interop.Word.WdUnits.wdTable;
            object which;
            which = Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst;
            object count;
            count = 1;
            oWordApplic.Selection.GoTo(ref what, ref which, ref count, ref missing);
            oWordApplic.Selection.Find.ClearFormatting();

            oWordApplic.Selection.Text = "";


        }

        public static void GoToRightCell()
        {
            // Selection.MoveRight Unit:=wdCell

            object missing = System.Reflection.Missing.Value;
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdCell;
            oWordApplic.Selection.MoveRight(ref direction, ref missing, ref missing);
        }

        public static void GoToLeftCell()
        {
            // Selection.MoveRight Unit:=wdCell

            object missing = System.Reflection.Missing.Value;
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdCell;
            oWordApplic.Selection.MoveLeft(ref direction, ref missing, ref missing);
        }

        public static void GoToDownCell()
        {
            // Selection.MoveRight Unit:=wdCell

            object missing = System.Reflection.Missing.Value;
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            oWordApplic.Selection.MoveDown(ref direction, ref missing, ref missing);
        }

        public static void GoToUpCell()
        {
            // Selection.MoveRight Unit:=wdCell

            object missing = System.Reflection.Missing.Value;
            object direction;
            direction = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            oWordApplic.Selection.MoveUp(ref direction, ref missing, ref missing);
        }

        // this function doesn't work
        //public void InsertPageNumber(string strType, bool bHeader)
        //{
        //    object missing = System.Reflection.Missing.Value;
        //    object alignment;
        //    object bFirstPage = false;
        //    object bF = true;
        //    //if (bHeader == true)
        //    //WordApplic.Selection.HeaderFooter.PageNumbers.ShowFirstPageNumber = bF;
        //    switch (strType)
        //    {
        //        case "Center":
        //            alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;
        //            //WordApplic.Selection.HeaderFooter.PageNumbers.Add(ref alignment,ref bFirstPage);
        //            //Word.Selection objSelection = WordApplic.pSelection;

        //            oWordApplic.Selection.HeaderFooter.PageNumbers.Item(1).Alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberCenter;
        //            break;
        //        case "Right":
        //            alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberRight;
        //            oWordApplic.Selection.HeaderFooter.PageNumbers.Item(1).Alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberRight;
        //            break;
        //        case "Left":
        //            alignment = Microsoft.Office.Interop.Word.WdPageNumberAlignment.wdAlignPageNumberLeft;
        //            oWordApplic.Selection.HeaderFooter.PageNumbers.Add(ref alignment, ref bFirstPage);
        //            break;
        //    }

        //}

    }
    //object units = WdUnits.wdCharacter;
    //object last=doc.Characters.Count;
    //doc.Range(ref first, ref last).Delete(ref units, ref last)
}

