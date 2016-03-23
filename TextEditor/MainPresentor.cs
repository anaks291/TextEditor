using System;
using TextEditor.BL;

namespace TextEditor
{    
    class MainPresentor
    {
        private readonly IMainForm _viev;
        private readonly IFileManager _manager;
        private readonly IMessageService _messageService;

        private string _currentFilePath;

        public MainPresentor (IMainForm viev, IFileManager manager, IMessageService messageService)
        {
            _viev = viev;
            _manager = manager;
            _messageService = messageService;

            _viev.SetSimbolCount(0);

            _viev.ContentChaiged += _viev_ContentChaiged;
            _viev.FileOpenClick += _viev_FileOpenClick;
            _viev.FileSaveClick += _viev_FileSaveClick;
        }

        private void _viev_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _viev.Content;

                _manager.SaveContent(content, _currentFilePath);

                _messageService.ShowMessage("Файл успешно сохранен");
            }

            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _viev_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _viev.FilePath;

                bool isExist = _manager.IsExist(filePath);

                if (!isExist)
                {
                    _messageService.ShowExclamation("ВЫбранный файл не существует");
                    return;
                }

                _currentFilePath = filePath;

                string content = _manager.GetContent(filePath);
                int count = _manager.GetSimbolCount(content);

                _viev.Content = content;
                _viev.SetSimbolCount(count);
            }

            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        private void _viev_ContentChaiged(object sender, EventArgs e)
        {
            string content = _viev.Content;
            int count = _manager.GetSimbolCount(content);
            _viev.SetSimbolCount(count);
        }
    }
}
