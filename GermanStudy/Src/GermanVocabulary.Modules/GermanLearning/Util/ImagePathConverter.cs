using System;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GermanLearningModule.Util
{
    /// <summary>
    /// Class of Image path converter.
    /// The class gives the image path according to the value of the AnswerState
    /// </summary>
    public class ImagePathConverter : IValueConverter
    {
        private string _imageDirectory = Directory.GetCurrentDirectory();
        public string ImageDirectory
        {
            get { return _imageDirectory; }
            set { _imageDirectory = value; }
        }

        /// <summary>
        /// method converts image path according to the value of the AnswerState
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imagePath;
            AnswerState answerState = (AnswerState)value;
            
            if ( answerState == AnswerState.Right )
            {
                imagePath = "../Resources/right.png";
            }
            else if (answerState == AnswerState.Wrong)
            {
                imagePath = "../Resources/cross.png";
            }
            else
            {
                imagePath = "../Resources/noShow.png";
            }

            Uri uri = new Uri(imagePath, UriKind.Relative);

            return new BitmapImage(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("The method or operation is not implemented.");
        }
    }
}
