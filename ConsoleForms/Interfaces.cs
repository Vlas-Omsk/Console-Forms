using System;
using System.Text;
using PinkConsoleForms.PinkWinApi;

namespace PinkConsoleForms
{
    public interface IConsoleForms
    {
        /// <summary>
        /// Содержит HANDLE консоли
        /// </summary>
        IntPtr ConsoleHWND { get; }

        /// <summary>
        /// Содержимое консоли
        /// </summary>
        StringBuilder ConsoleText { get; }

        /// <summary>
        /// Устанавливает, будет ли буффер консоли равняться размерам консоли
        /// </summary>
        bool BufferEqualsSize { get; set; }


        #region --- Console Font Info ---
        /// <summary>
        /// Получает или задает размер символа консоли в пикселях
        /// </summary>
        Size ConsoleCharSize { get; set; }

        /// <summary>
        /// Получает или задает наименование шрифта в консоле
        /// </summary>
        ConsoleFont ConsoleFont { get; set; }
        #endregion

        #region ---      Cursor       ---
        /// <summary>
        /// Получает или задает координаты консольного курсора
        /// </summary>
        Point Cursor { get; set; }

        /// <summary>
        /// Перемещает курсор консоли в указанные координаты, отсчет от левого верхнего угла
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void GoToXY(int x, int y);

        /// <summary>
        /// Перемещает курсор консоли в указанные координаты, отсчет от левого верхнего угла
        /// </summary>
        /// <param name="p"></param>
        void GoToXY(Point p);
        #endregion

        #region ---  Console Window   ---
        /// <summary>
        /// Отображает окно в полный экран
        /// </summary>
        bool FullScreen { get; set; }

        /// <summary>
        /// Получает или задает размер консоли в столбцах и строках
        /// </summary>
        Size ConsoleSize { get; set; }

        /// <summary>
        /// Получает или задает прямоугольник с экранными координатами окна консоли
        /// </summary>
        Rect ConsoleWindowRect { get; set; }

        /// <summary>
        /// Получает прямоугольник с экранными координатами окна консоли
        /// </summary>
        /// <returns></returns>
        Rect GetWindow();

        /// <summary>
        /// Получает размер окна консоли в экранных координатах
        /// </summary>
        /// <returns></returns>
        Size GetWindowSize();

        /// <summary>
        /// Получает экранные координаты левой верхней точки окна консоли
        /// </summary>
        /// <returns></returns>
        Point GetWindowPoint();

        /// <summary>
        /// Получает размеры экрана
        /// </summary>
        /// <returns></returns>
        Rect ScreenRect();

        /// <summary>
        /// Получает размеры экрана
        /// </summary>
        /// <returns></returns>
        Size ScreenSize();

        /// <summary>
        /// Устанавливает окно консоли в координаты x, y, и здает ширину и высоту width, height в экранных координатах
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="state"></param>
        void SetWindow(int x, int y, int width, int height, WindowState state);

        /// <summary>
        /// Устанавливает ширину и высоту width, height в консольных координатах
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void SetConsoleSize(int width, int height);

        /// <summary>
        /// Устанавливает флаги стилей окна консоли
        /// </summary>
        /// <param name="flags"></param>
        void SetWindowFlags(params WindowStyles[] flags);

        /// <summary>
        /// Закрывает окно быстро, без подтверждений
        /// </summary>
        /// <returns></returns>
        IntPtr CloseWindowQuickly();

        /// <summary>
        /// Получает фокус для консоли
        /// </summary>
        /// <returns></returns>
        bool GotFocus();
        #endregion

        #region ---      Windows      ---
        /// <summary>
        /// Получает handle активного окна
        /// </summary>
        /// <returns></returns>
        IntPtr GetForegroundWindow();

        /// <summary>
        /// Задает активное окно по handle
        /// </summary>
        /// <param name="hWnd">handle окна</param>
        /// <returns></returns>
        bool SetForegroundWindow(IntPtr hWnd);
        #endregion

        #region ---       Mouse       ---
        /// <summary>
        /// Получает координаты мыши в экранных координатах
        /// </summary>
        /// <returns></returns>
        Point GetMCursorPositionScreen();

        /// <summary>
        /// Получает координаты мыши в экранных координатах, где нулевыми координатами будет начало окна консоли, если курсор находится вне окна возвращает null
        /// </summary>
        /// <returns></returns>
        Point GetMCursorPositionWindow();

        /// <summary>
        /// Получает координаты мыши в консольных координатах, если курсор находится вне окна возвращает null
        /// </summary>
        /// <returns></returns>
        Point GetMCursorPositionConsole();

        /// <summary>
        /// Получает нажатую кнопку мыши в области экрана
        /// </summary>
        /// <returns></returns>
        MButton GetMouseButtonScreen();

        /// <summary>
        /// Получает нажатую кнопку мыши в области окна консоли, если курсор находится вне окна возвращает MButton.Null
        /// </summary>
        /// <returns></returns>
        MButton GetMouseButtonConsole();

        /// <summary>
        /// Устанавливает курсор мыши в позицию x y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool SetCursorPos(int x, int y);

        /// <summary>
        /// Устанавливает отображение системного курсора (Работает не всегда)
        /// </summary>
        /// <param name="show"></param>
        /// <returns></returns>
        int ShowCursor(bool show);
        #endregion

        #region ---     Keyboard      ---
        /// <summary>
        /// Блокирует ввод с клавиатуры
        /// </summary>
        bool LockKeyboardWriting { get; set; }

        /// <summary>
        /// Получает информацию была ли нажата клавиша key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        short GetKeyState(int key);
        #endregion

        #region ---  Console Buffer   ---
        /// <summary>
        /// Устанавливает размер буфера равным размеру окна
        /// </summary>
        void SetBufferEqualsSize();

        /// <summary>
        /// Получает символ из окна консоли с координатами x y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        char GetChar(int x, int y);

        /// <summary>
        /// Сохраняет изображение консоли в виде текстового документа с кодировкой cp866
        /// </summary>
        /// <param name="path"></param>
        void SaveConsole(string path);
        #endregion

        #region ---       Other       ---
        /// <summary>
        /// Включает или отключает выделение мышью и быструю вставку
        /// </summary>
        bool QuickEditMode { set; }

        /// <summary>
        /// Очищает окно консоли и ее буфер
        /// </summary>
        void Clear();

        /// <summary>
        /// Получает, является ли текущая операционная система Windows 10 или Windows 8
        /// </summary>
        /// <returns></returns>
        bool IsWindows10();
        #endregion
    }
}
