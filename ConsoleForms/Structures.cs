namespace PinkConsoleForms
{
    /// <summary>
    /// <para>Задает клавиши мыши</para>
    /// <para>Specifies mouse keys</para>
    /// </summary>
    public enum MButton
    {
        Null, 
        Right, 
        Left, 
        Center, 
        XBUTTON1, 
        XBUTTON2
    }

    /// <summary>
    /// <para>Задает все возможные коды клавиш</para>
    /// <para>Specifies all possible key codes</para>
    /// </summary>
    public enum Keys
    {
        /// <summary>
        /// Left mouse button
        /// </summary>
        VK_LBUTTON = 1,
        /// <summary>
        /// Right mouse button
        /// </summary>
        VK_RBUTTON = 2,
        /// <summary>
        /// Control-break processing
        /// </summary>
        VK_CANCEL = 3,
        /// <summary>
        /// Middle mouse button (three-button mouse)
        /// </summary>
        VK_MBUTTON = 4,
        /// <summary>
        /// X1 mouse button
        /// </summary>
        VK_XBUTTON1 = 5,
        /// <summary>
        /// X2 mouse button
        /// </summary>
        VK_XBUTTON2 = 6,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined = 7,
        /// <summary>
        /// BACKSPACE key
        /// </summary>
        VK_BACK = 8,
        /// <summary>
        /// TAB key
        /// </summary>
        VK_TAB = 9,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved = 10,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved_2 = 11,
        /// <summary>
        /// CLEAR key
        /// </summary>
        VK_CLEAR = 12,
        /// <summary>
        /// ENTER key
        /// </summary>
        VK_RETURN = 13,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined3 = 14,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined3_2 = 15,
        /// <summary>
        /// SHIFT key
        /// </summary>
        VK_SHIFT = 16,
        /// <summary>
        /// CTRL key
        /// </summary>
        VK_CONTROL = 17,
        /// <summary>
        /// ALT key
        /// </summary>
        VK_MENU = 18,
        /// <summary>
        /// PAUSE key
        /// </summary>
        VK_PAUSE = 19,
        /// <summary>
        /// CAPS LOCK key
        /// </summary>
        VK_CAPITAL = 20,
        /// <summary>
        /// IME Kana mode
        /// </summary>
        VK_KANA = 21,
        /// <summary>
        /// IME Hanguel mode (maintained for compatibility; use VK_HANGUL)
        /// </summary>
        VK_HANGUEL = 21,
        /// <summary>
        /// IME Hangul mode
        /// </summary>
        VK_HANGUL = 21,
        /// <summary>
        /// IME On
        /// </summary>
        VK_IME_ON = 22,
        /// <summary>
        /// IME Junja mode
        /// </summary>
        VK_JUNJA = 23,
        /// <summary>
        /// IME final mode
        /// </summary>
        VK_FINAL = 24,
        /// <summary>
        /// IME Hanja mode
        /// </summary>
        VK_HANJA = 25,
        /// <summary>
        /// IME Kanji mode
        /// </summary>
        VK_KANJI = 25,
        /// <summary>
        /// IME Off
        /// </summary>
        VK_IME_OFF = 26,
        /// <summary>
        /// ESC key
        /// </summary>
        VK_ESCAPE = 27,
        /// <summary>
        /// IME convert
        /// </summary>
        VK_CONVERT = 28,
        /// <summary>
        /// IME nonconvert
        /// </summary>
        VK_NONCONVERT = 29,
        /// <summary>
        /// IME accept
        /// </summary>
        VK_ACCEPT = 30,
        /// <summary>
        /// IME mode change request
        /// </summary>
        VK_MODECHANGE = 31,
        /// <summary>
        /// SPACEBAR
        /// </summary>
        VK_SPACE = 32,
        /// <summary>
        /// PAGE UP key
        /// </summary>
        VK_PRIOR = 33,
        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        VK_NEXT = 34,
        /// <summary>
        /// END key
        /// </summary>
        VK_END = 35,
        /// <summary>
        /// HOME key
        /// </summary>
        VK_HOME = 36,
        /// <summary>
        /// LEFT ARROW key
        /// </summary>
        VK_LEFT = 37,
        /// <summary>
        /// UP ARROW key
        /// </summary>
        VK_UP = 38,
        /// <summary>
        /// RIGHT ARROW key
        /// </summary>
        VK_RIGHT = 39,
        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        VK_DOWN = 40,
        /// <summary>
        /// SELECT key
        /// </summary>
        VK_SELECT = 41,
        /// <summary>
        /// PRINT key
        /// </summary>
        VK_PRINT = 42,
        /// <summary>
        /// EXECUTE key
        /// </summary>
        VK_EXECUTE = 43,
        /// <summary>
        /// PRINT SCREEN key
        /// </summary>
        VK_SNAPSHOT = 44,
        /// <summary>
        /// INS key
        /// </summary>
        VK_INSERT = 45,
        /// <summary>
        /// DEL key
        /// </summary>
        VK_DELETE = 46,
        /// <summary>
        /// HELP key
        /// </summary>
        VK_HELP = 47,
        key0 = 48,
        key1 = 49,
        key2 = 50,
        key3 = 51,
        key4 = 52,
        key5 = 53,
        key6 = 54,
        key7 = 55,
        key8 = 56,
        key9 = 57,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined2 = 58,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined2_2 = 59,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined2_3 = 60,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined2_4 = 61,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined2_5 = 62,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined2_6 = 63,
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined2_7 = 64,
        A_key = 65,
        B_key = 66,
        C_key = 67,
        D_key = 68,
        E_key = 69,
        F_key = 70,
        G_key = 71,
        H_key = 72,
        I_key = 73,
        J_key = 74,
        K_key = 75,
        L_key = 76,
        M_key = 77,
        N_key = 78,
        O_key = 79,
        P_key = 80,
        Q_key = 81,
        R_key = 82,
        S_key = 83,
        T_key = 84,
        U_key = 85,
        V_key = 86,
        W_key = 87,
        X_key = 88,
        Y_key = 89,
        Z_key = 90,
        /// <summary>
        /// Left Windows key (Natural keyboard)
        /// </summary>
        VK_LWIN = 91,
        /// <summary>
        /// Right Windows key (Natural keyboard)
        /// </summary>
        VK_RWIN = 92,
        /// <summary>
        /// Applications key (Natural keyboard)
        /// </summary>
        VK_APPS = 93,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved2 = 94,
        /// <summary>
        /// Computer Sleep key
        /// </summary>
        VK_SLEEP = 95,
        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        VK_NUMPAD0 = 96,
        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        VK_NUMPAD1 = 97,
        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        VK_NUMPAD2 = 98,
        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        VK_NUMPAD3 = 99,
        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        VK_NUMPAD4 = 100,
        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        VK_NUMPAD5 = 101,
        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        VK_NUMPAD6 = 102,
        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        VK_NUMPAD7 = 103,
        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        VK_NUMPAD8 = 104,
        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        VK_NUMPAD9 = 105,
        /// <summary>
        /// Multiply key
        /// </summary>
        VK_MULTIPLY = 106,
        /// <summary>
        /// Add key
        /// </summary>
        VK_ADD = 107,
        /// <summary>
        /// Separator key
        /// </summary>
        VK_SEPARATOR = 108,
        /// <summary>
        /// Subtract key
        /// </summary>
        VK_SUBTRACT = 109,
        /// <summary>
        /// Decimal key
        /// </summary>
        VK_DECIMAL = 110,
        /// <summary>
        /// Divide key
        /// </summary>
        VK_DIVIDE = 111,
        /// <summary>
        /// F1 key
        /// </summary>
        VK_F1 = 112,
        /// <summary>
        /// F2 key
        /// </summary>
        VK_F2 = 113,
        /// <summary>
        /// F3 key
        /// </summary>
        VK_F3 = 114,
        /// <summary>
        /// F4 key
        /// </summary>
        VK_F4 = 115,
        /// <summary>
        /// F5 key
        /// </summary>
        VK_F5 = 116,
        /// <summary>
        /// F6 key
        /// </summary>
        VK_F6 = 117,
        /// <summary>
        /// F7 key
        /// </summary>
        VK_F7 = 118,
        /// <summary>
        /// F8 key
        /// </summary>
        VK_F8 = 119,
        /// <summary>
        /// F9 key
        /// </summary>
        VK_F9 = 120,
        /// <summary>
        /// F10 key
        /// </summary>
        VK_F10 = 121,
        /// <summary>
        /// F11 key
        /// </summary>
        VK_F11 = 122,
        /// <summary>
        /// F12 key
        /// </summary>
        VK_F12 = 123,
        /// <summary>
        /// F13 key
        /// </summary>
        VK_F13 = 124,
        /// <summary>
        /// F14 key
        /// </summary>
        VK_F14 = 125,
        /// <summary>
        /// F15 key
        /// </summary>
        VK_F15 = 126,
        /// <summary>
        /// F16 key
        /// </summary>
        VK_F16 = 127,
        /// <summary>
        /// F17 key
        /// </summary>
        VK_F17 = 128,
        /// <summary>
        /// F18 key
        /// </summary>
        VK_F18 = 129,
        /// <summary>
        /// F19 key
        /// </summary>
        VK_F19 = 130,
        /// <summary>
        /// F20 key
        /// </summary>
        VK_F20 = 131,
        /// <summary>
        /// F21 key
        /// </summary>
        VK_F21 = 132,
        /// <summary>
        /// F22 key
        /// </summary>
        VK_F22 = 133,
        /// <summary>
        /// F23 key
        /// </summary>
        VK_F23 = 134,
        /// <summary>
        /// F24 key
        /// </summary>
        VK_F24 = 135,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4 = 136,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4_2 = 137,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4_3 = 138,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4_4 = 139,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4_5 = 140,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4_6 = 141,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4_7 = 142,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned4_8 = 143,
        /// <summary>
        /// NUM LOCK key
        /// </summary>
        VK_NUMLOCK = 144,
        /// <summary>
        /// SCROLL LOCK key
        /// </summary>
        VK_SCROLL = 145,
        OEM_specific = 146,
        OEM_specific_2 = 147,
        OEM_specific_3 = 148,
        OEM_specific_4 = 149,
        OEM_specific_5 = 150,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5 = 151,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_2 = 152,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_3 = 153,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_4 = 154,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_5 = 155,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_6 = 156,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_7 = 157,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_8 = 158,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned5_9 = 159,
        /// <summary>
        /// Left SHIFT key
        /// </summary>
        VK_LSHIFT = 160,
        /// <summary>
        /// Right SHIFT key
        /// </summary>
        VK_RSHIFT = 161,
        /// <summary>
        /// Left CONTROL key
        /// </summary>
        VK_LCONTROL = 162,
        /// <summary>
        /// Right CONTROL key
        /// </summary>
        VK_RCONTROL = 163,
        /// <summary>
        /// Left MENU key
        /// </summary>
        VK_LMENU = 164,
        /// <summary>
        /// Right MENU key
        /// </summary>
        VK_RMENU = 165,
        /// <summary>
        /// Browser Back key
        /// </summary>
        VK_BROWSER_BACK = 166,
        /// <summary>
        /// Browser Forward key
        /// </summary>
        VK_BROWSER_FORWARD = 167,
        /// <summary>
        /// Browser Refresh key
        /// </summary>
        VK_BROWSER_REFRESH = 168,
        /// <summary>
        /// Browser Stop key
        /// </summary>
        VK_BROWSER_STOP = 169,
        /// <summary>
        /// Browser Search key
        /// </summary>
        VK_BROWSER_SEARCH = 170,
        /// <summary>
        /// Browser Favorites key
        /// </summary>
        VK_BROWSER_FAVORITES = 171,
        /// <summary>
        /// Browser Start and Home key
        /// </summary>
        VK_BROWSER_HOME = 172,
        /// <summary>
        /// Volume Mute key
        /// </summary>
        VK_VOLUME_MUTE = 173,
        /// <summary>
        /// Volume Down key
        /// </summary>
        VK_VOLUME_DOWN = 174,
        /// <summary>
        /// Volume Up key
        /// </summary>
        VK_VOLUME_UP = 175,
        /// <summary>
        /// Next Track key
        /// </summary>
        VK_MEDIA_NEXT_TRACK = 176,
        /// <summary>
        /// Previous Track key
        /// </summary>
        VK_MEDIA_PREV_TRACK = 177,
        /// <summary>
        /// Stop Media key
        /// </summary>
        VK_MEDIA_STOP = 178,
        /// <summary>
        /// Play/Pause Media key
        /// </summary>
        VK_MEDIA_PLAY_PAUSE = 179,
        /// <summary>
        /// Start Mail key
        /// </summary>
        VK_LAUNCH_MAIL = 180,
        /// <summary>
        /// Select Media key
        /// </summary>
        VK_LAUNCH_MEDIA_SELECT = 181,
        /// <summary>
        /// Start Application 1 key
        /// </summary>
        VK_LAUNCH_APP1 = 182,
        /// <summary>
        /// Start Application 2 key
        /// </summary>
        VK_LAUNCH_APP2 = 183,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved3 = 184,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved3_2 = 185,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ';:' key
        /// </summary>
        VK_OEM_1 = 186,
        /// <summary>
        /// For any country/region, the '+' key
        /// </summary>
        VK_OEM_PLUS = 187,
        /// <summary>
        /// For any country/region, the ',' key
        /// </summary>
        VK_OEM_COMMA = 188,
        /// <summary>
        /// For any country/region, the '-' key
        /// </summary>
        VK_OEM_MINUS = 189,
        /// <summary>
        /// For any country/region, the '.' key
        /// </summary>
        VK_OEM_PERIOD = 190,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '/?' key
        /// </summary>
        VK_OEM_2 = 191,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '`~' key
        /// </summary>
        VK_OEM_3 = 192,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4 = 193,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_2 = 194,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_3 = 195,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_4 = 196,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_5 = 197,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_6 = 198,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_7 = 199,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_8 = 200,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_9 = 201,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_10 = 202,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_11 = 203,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_12 = 204,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_13 = 205,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_14 = 206,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_15 = 207,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_16 = 208,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_17 = 209,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_18 = 210,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_19 = 211,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_20 = 212,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_21 = 213,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_22 = 214,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved4_23 = 215,
        /// <summary>
        /// Reserved
        /// </summary>
        Unassigned6 = 216,
        /// <summary>
        /// Reserved
        /// </summary>
        Unassigned6_2 = 217,
        /// <summary>
        /// Reserved
        /// </summary>
        Unassigned6_3 = 218,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '[{' key
        /// </summary>
        VK_OEM_4 = 219,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '\|' key
        /// </summary>
        VK_OEM_5 = 220,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ']}' key
        /// </summary>
        VK_OEM_6 = 221,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the 'single-quote/double-quote' key
        /// </summary>
        VK_OEM_7 = 222,
        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        VK_OEM_8 = 223,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved5 = 224,
        OEM_specific2 = 225,
        /// <summary>
        /// Either the angle bracket key or the backslash key on the RT 102-key keyboard
        /// </summary>
        VK_OEM_102 = 226,
        OEM_specific3 = 227,
        OEM_specific3_2 = 228,
        /// <summary>
        /// IME PROCESS key
        /// </summary>
        VK_PROCESSKEY = 229,
        OEM_specific4 = 230,
        /// <summary>
        /// Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        /// </summary>
        VK_PACKET = 231,
        /// <summary>
        /// Unassigned
        /// </summary>
        Unassigned7 = 232,
        OEM_specific5 = 233,
        OEM_specific5_2 = 234,
        OEM_specific5_3 = 235,
        OEM_specific5_4 = 236,
        OEM_specific5_5 = 237,
        OEM_specific5_6 = 238,
        OEM_specific5_7 = 239,
        OEM_specific5_8 = 240,
        OEM_specific5_9 = 241,
        OEM_specific5_10 = 242,
        OEM_specific5_11 = 243,
        OEM_specific5_12 = 244,
        OEM_specific5_13 = 245,
        /// <summary>
        /// Attn key
        /// </summary>
        VK_ATTN = 246,
        /// <summary>
        /// CrSel key
        /// </summary>
        VK_CRSEL = 247,
        /// <summary>
        /// ExSel key
        /// </summary>
        VK_EXSEL = 248,
        /// <summary>
        /// Erase EOF key
        /// </summary>
        VK_EREOF = 249,
        /// <summary>
        /// Play key
        /// </summary>
        VK_PLAY = 250,
        /// <summary>
        /// Zoom key
        /// </summary>
        VK_ZOOM = 251,
        /// <summary>
        /// Reserved
        /// </summary>
        VK_NONAME = 252,
        /// <summary>
        /// PA1 key
        /// </summary>
        VK_PA1 = 253,
        /// <summary>
        /// Clear key
        /// </summary>
        VK_OEM_CLEAR = 254
    };

    /// <summary>
    /// <para>Представляет позицию окна в Z-порядке</para>
    /// <para>Represents the position of a window in Z-order</para>
    /// </summary>
    public enum WindowState
    {
        /// <summary>
        /// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows.
        /// </summary>
        HWND_BOTTOM = 1,
        /// <summary>
        /// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window.
        /// </summary>
        HWND_NOTOPMOST = -2,
        /// <summary>
        /// Places the window at the top of the Z order.
        /// </summary>
        HWND_TOP = 0,
        /// <summary>
        /// Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.
        /// </summary>
        HWND_TOPMOST = -1
    };

    /// <summary>
    /// <para>Представляет стили окон Windows</para>
    /// <para>Represents Windows window styles</para>
    /// </summary>
    public enum WindowStyles : ulong
    {
        /// <summary>
        /// The window has a thin-line border.
        /// </summary>
        WS_BORDER = 8388608,
        /// <summary>
        /// The window has a title bar (includes the WS_BORDER style).
        /// </summary>
        WS_CAPTION = 12582912,
        /// <summary>
        /// The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.
        /// </summary>
        WS_CHILD = 1073741824,
        /// <summary>
        /// Same as the WS_CHILD style.
        /// </summary>
        WS_CHILDWINDOW = 1073741824,
        /// <summary>
        /// Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.
        /// </summary>
        WS_CLIPCHILDREN = 33554432,
        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
        /// </summary>
        WS_CLIPSIBLINGS = 67108864,
        /// <summary>
        /// The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.
        /// </summary>
        WS_DISABLED = 895981,
        /// <summary>
        /// The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.
        /// </summary>
        WS_DLGFRAME = 4194304,
        /// <summary>
        /// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style. The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys. You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function.
        /// </summary>
        WS_GROUP = 131072,
        /// <summary>
        /// The window has a horizontal scroll bar.
        /// </summary>
        WS_HSCROLL = 1048576,
        /// <summary>
        /// The window is initially minimized. Same as the WS_MINIMIZE style.
        /// </summary>
        WS_ICONIC = 536870912,
        /// <summary>
        /// The window is initially maximized.
        /// </summary>
        WS_MAXIMIZE = 16777216,
        /// <summary>
        /// The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
        /// </summary>
        WS_MAXIMIZEBOX = 65536,
        /// <summary>
        /// The window is initially minimized. Same as the WS_ICONIC style.
        /// </summary>
        WS_MINIMIZE = 536870912,
        /// <summary>
        /// The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style. The WS_SYSMENU style must also be specified.
        /// </summary>
        WS_MINIMIZEBOX = 131072,
        /// <summary>
        /// The window is an overlapped window. An overlapped window has a title bar and a border. Same as the WS_TILED style.
        /// </summary>
        WS_OVERLAPPED = 0,
        /// <summary>
        /// The windows is a pop-up window. This style cannot be used with the WS_CHILD style.
        /// </summary>
        WS_POPUP = 2147483648,
        /// <summary>
        /// The window has a sizing border. Same as the WS_THICKFRAME style.
        /// </summary>
        WS_SIZEBOX = 262144,
        /// <summary>
        /// The window has a window menu on its title bar. The WS_CAPTION style must also be specified.
        /// </summary>
        WS_SYSMENU = 524288,
        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key. Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style. You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the SetWindowLong function. For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
        /// </summary>
        WS_TABSTOP = 65536,
        /// <summary>
        /// The window has a sizing border. Same as the WS_SIZEBOX style.
        /// </summary>
        WS_THICKFRAME = 262144,
        /// <summary>
        /// The window is an overlapped window. An overlapped window has a title bar and a border. Same as the WS_OVERLAPPED style.
        /// </summary>
        WS_TILED = 0,
        /// <summary>
        /// The window is initially visible. This style can be turned on and off by using the ShowWindow or SetWindowPos function.
        /// </summary>
        WS_VISIBLE = 268435456,
        /// <summary>
        /// The window has a vertical scroll bar.
        /// </summary>
        WS_VSCROLL = 2097152
    };

    ///// <summary>
    ///// <para>Задает константы, которые определяют основной цвет и цвет фона консоли.</para>
    ///// <para>Specifies constants that define the foreground and background colors of the console.</para>
    ///// </summary>
    //public enum ConsoleColor
    //{
    //    /// <summary>
    //    /// <para>Черный цвет.</para>
    //    /// <para>Black color.</para>
    //    /// </summary>
    //    Black = 0,
    //    /// <summary>
    //    /// <para>Темно-синий цвет.</para>
    //    /// <para>Dark blue color.</para>
    //    /// </summary>
    //    DarkBlue = 1,
    //    /// <summary>
    //    /// <para>Темно-зеленый цвет.</para>
    //    /// <para>Dark green color.</para>
    //    /// </summary>
    //    DarkGreen = 2,
    //    /// <summary>
    //    /// <para>Темно-голубой цвет (темный сине-зеленый).</para>
    //    /// <para>Dark blue color (dark blue-green).</para>
    //    /// </summary>
    //    DarkCyan = 3,
    //    /// <summary>
    //    /// <para>Темно-красный цвет.</para>
    //    /// <para>Dark red color.</para>
    //    /// </summary>
    //    DarkRed = 4,
    //    /// <summary>
    //    /// <para>Темно-пурпурный цвет (темный фиолетово-красный).</para>
    //    /// <para>Dark purple color (dark purple-red).</para>
    //    /// </summary>
    //    DarkMagenta = 5,
    //    /// <summary>
    //    /// <para>Темно-желтый цвет (коричнево-желтый).</para>
    //    /// <para>Dark yellow color (brownish yellow).</para>
    //    /// </summary>
    //    DarkYellow = 6,
    //    /// <summary>
    //    /// <para>Серый цвет.</para>
    //    /// <para>Grey color.</para>
    //    /// </summary>
    //    Gray = 7,
    //    /// <summary>
    //    /// <para>Темно-серый цвет.</para>
    //    /// <para>Dark gray color.</para>
    //    /// </summary>
    //    DarkGray = 8,
    //    /// <summary>
    //    /// <para>Синий цвет.</para>
    //    /// <para>Blue color.</para>
    //    /// </summary>
    //    Blue = 9,
    //    /// <summary>
    //    /// <para>Зеленый цвет.</para>
    //    /// <para>Green color.</para>
    //    /// </summary>
    //    Green = 10,
    //    /// <summary>
    //    /// <para>Голубой цвет (сине-зеленый).</para>
    //    /// <para>Light blue (blue-green).</para>
    //    /// </summary>
    //    Cyan = 11,
    //    /// <summary>
    //    /// <para>Красный цвет.</para>
    //    /// <para>Red color.</para>
    //    /// </summary>
    //    Red = 12,
    //    /// <summary>
    //    /// <para>Пурпурный цвет (фиолетово-красный).</para>
    //    /// <para>Magenta color (violet-red).</para>
    //    /// </summary>
    //    Magenta = 13,
    //    /// <summary>
    //    /// <para>Желтый цвет.</para>
    //    /// <para>Yellow color.</para>
    //    /// </summary>
    //    Yellow = 14,
    //    /// <summary>
    //    /// <para>Белый цвет.</para>
    //    /// <para>White color.</para>
    //    /// </summary>
    //    White = 15
    //}

    /// <summary>
    /// <para>Задает константы, которые определяют основной цвет и цвет фона консоли.</para>
    /// <para>Specifies constants that define the foreground and background colors of the console.</para>
    /// </summary>
    public class ConsoleFont
    {
        public string FontName;

        public ConsoleFont(string fontname)
        {
            FontName = fontname;
        }

        public override string ToString()
        {
            return FontName;
        }

        public static ConsoleFont Consolas = new ConsoleFont("Consolas");
        public static ConsoleFont CourierNew = new ConsoleFont("Courier New");
        public static ConsoleFont LucidaConsole = new ConsoleFont("Lucida Console");
        public static ConsoleFont MSGothic = new ConsoleFont("MS Gothic");
        public static ConsoleFont NSimSun = new ConsoleFont("NSimSun");
        public static ConsoleFont SimSunExtB = new ConsoleFont("SimSun-ExtB");
        public static ConsoleFont Terminal = new ConsoleFont("Terminal");
    }

    /// <summary>
    /// <para>Представляет точку на двумерной плоскости</para>
    /// <para>Represents a point on a two-dimensional plane</para>
    /// </summary>
    public struct Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    /// <summary>
    /// <para>Представляет ширину и высоту</para>
    /// <para>Represents width and height</para>
    /// </summary>
    public struct Size
    {
        public int Width, Height;

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }

    /// <summary>
    /// <para>Представляет прямоугольник с координатами сторон</para>
    /// <para>Represents a rectangle with side coordinates</para>
    /// </summary>
    public struct Rect
    {
        public int Left, Top, Right, Bottom;

        public int Width { get => Right - Left; }
        public int Height { get => Bottom - Top; }

        public Rect(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public Rect(Point point, Size size)
        {
            this.Left = point.X;
            this.Top = point.Y;
            this.Right = point.X + size.Width;
            this.Bottom = point.Y + size.Height;
        }

        public Rect(int all)
        {
            this.Left = all;
            this.Top = all;
            this.Right = all;
            this.Bottom = all;
        }


        public static Rect operator +(Rect left, Rect right)
        {
            return new Rect(left.Left + right.Left,
                left.Top + right.Top,
                left.Right + right.Right,
                left.Bottom + right.Bottom);
        }

        public static Rect operator -(Rect left, Rect right)
        {
            return new Rect(left.Left - right.Left,
                left.Top - right.Top,
                left.Right - right.Right,
                left.Bottom - right.Bottom);
        }
    }

    /// <summary>
    /// <para>Представляет состояния поворота колесика мыши</para>
    /// <para>Represents the rotation state of the mouse wheel</para>
    /// </summary>
    public enum WheelState
    {
        Up,
        Down,
        Right,
        Left
    }

    /// <summary>
    /// <para>Представляет стандартные 16 цветов консоли</para>
    /// <para>Represents the standard 16 console colors</para>
    /// </summary>
    public enum Colors16
    {
        Black = 30,
        Red = 31,
        Green = 32,
        Yellow = 33,
        Blue = 34,
        Magenta = 35,
        Cyan = 36,
        White = 37,
        Reset = 0
    }

    /// <summary>
    /// <para>Представляет графические стили консоли</para>
    /// <para>Represents сonsole Graphic Styles</para>
    /// </summary>
    public enum VirtualStyles
    {
        Bold = 1,
        Dim = 2,
        Reset = 0
    }

    /// <summary>
    /// <para>Представляет цвет RGB (красный, зеленый, синий)</para>
    /// <para>Represents RGB color (red, green, blue)</para>
    /// </summary>
    public struct Color
    {
        public int R, G, B;

        public static Color FromRgb(int r, int g, int b)
        {
            var cl = new Color();

            cl.R = r;
            cl.G = g;
            cl.B = b;

            return cl;
        }

        public static Color FromColor(System.Drawing.Color cl)
        {
            var clr = new Color();

            clr.R = cl.R;
            clr.G = cl.G;
            clr.B = cl.B;

            return clr;
        }
    }
}
