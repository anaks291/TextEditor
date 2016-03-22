using System.IO;
using System.Text;


namespace TextEditor.BL
{
    public class FileManager
    {
        /// <summary>
        /// Кодировка по умолчанию Win(1251)
        /// </summary>
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        #region GetContent
        /// <summary>
        /// Перегруженный метод получающий контент с кодировкой по умолчанию
        /// </summary>
        /// <param name="FilePath">Путь к исходному файлу</param>
        /// <returns></returns>
        public string GetContent(string FilePath)
        {
            return GetContent(FilePath, _defaultEncoding);
           
        }

        /// <summary>
        /// Метод получающий контент исходного файла
        /// </summary>
        /// <param name="FilePath">Путь к исходному файлу</param>
        /// <param name="encoding">Кодировка исходного файла</param>
        /// <returns></returns>
        public string GetContent(string FilePath, Encoding encoding)
        {
            string content = File.ReadAllText(FilePath, encoding);
            return content;
        }
        #endregion


        #region SaveContent
        /// <summary>
        /// Перегруженнный метод сохранающий файл с кодировкой по умолчанию
        /// </summary>
        /// <param name="content">Содержимое для сохранения</param>
        /// <param name="filePath">Путь для сохранения</param>
        public void SaveContent(string content, string filePath)
        {
            File.WriteAllText(filePath, content, _defaultEncoding);
        }

        /// <summary>
        /// Метод записывающий контент в сохраняемый файл
        /// </summary>
        /// <param name="content">Содержимое для сохранения</param>
        /// <param name="filePath">Путь для сохранения</param>
        /// <param name="encoding">Кодировка в которой будет сохранен файл</param>
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        #endregion

        /// <summary>
        /// Метод проверки файла на существование
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }
        

        /// <summary>
        /// Метод возвращающий количество символов в содержимом файла
        /// </summary>
        /// <param name="content">Содержимое файла</param>
        /// <returns></returns>
        public int GetSimbolCount(string content)
        {
            int count = content.Length;
            return count;
        }

    }
}
