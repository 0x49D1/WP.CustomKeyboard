using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WP7.Keyboard.Interpreter;
using WP7.Keyboard.KeyboardMapping;
using Expression = WP7.Keyboard.Interpreter.Expression;

namespace WP7.Keyboard.Controls
{
    public abstract class Keyboard : Control
    {
        public Dictionary<string, string> ToUpperReplacement;
        private Expression _expression;
    
        public static readonly DependencyProperty IsSpaceVisibleProperty =
            DependencyProperty.Register("IsSpaceVisible", typeof(bool), typeof(Keyboard), new PropertyMetadata(true));
        public static readonly DependencyProperty IsSecondaryKeyboardVisibleProperty =
            DependencyProperty.Register("IsSecondaryKeyboardVisible", typeof(bool), typeof(Keyboard), new PropertyMetadata(true));
        public static readonly DependencyProperty IsCapsLockVisibleProperty =
            DependencyProperty.Register("IsCapsLockVisible", typeof(bool), typeof(Keyboard), new PropertyMetadata(true));
        public static readonly DependencyProperty IsInShiftModeProperty =
            DependencyProperty.Register("IsInShiftMode", typeof(bool), typeof(Keyboard), new PropertyMetadata(false, OnInShiftModeChanged));
        public static readonly DependencyProperty IsInSymbolModeProperty =
            DependencyProperty.Register("IsInSymbolMode", typeof(bool), typeof(Keyboard), new PropertyMetadata(false, OnInSymbolModeChanged));

        public event EventHandler<KeyEventArgs> KeyClicked;
        public event EventHandler SpaceKeyClicked;
        public event EventHandler BackspaceKeyClicked;
        public event EventHandler EnterKeyClicked;

        private Grid keysGrid;
        private KeyboardContext keyboardContext;
        private KeyboardContext secondaryKeybordContext;
        private Button shiftButton;
        private Button symbolButton;
        private Button spaceButton;
        private Button backspaceButton;
        private Button enterButton;

        protected Keyboard()
        {
            this.DefaultStyleKey = typeof(Keyboard);
            this.Expression = new DefaultExpression();
        }

        public bool IsSpaceVisible
        {
            get
            {
                return (bool)GetValue(IsSpaceVisibleProperty);
            }
            set
            {
                SetValue(IsSpaceVisibleProperty, value);
            }
        }

        public bool IsSecondaryKeyboardVisible
        {
            get
            {
                return (bool)GetValue(IsSecondaryKeyboardVisibleProperty);
            }
            set
            {
                SetValue(IsSecondaryKeyboardVisibleProperty, value);
            }
        }

        public bool IsCapsLockVisible
        {
            get
            {
                return (bool)GetValue(IsCapsLockVisibleProperty);
            }
            set
            {
                SetValue(IsCapsLockVisibleProperty, value);
            }
        }

        public bool IsInShiftMode
        {
            get
            {
                return (bool)GetValue(IsInShiftModeProperty);
            }
            set
            {
                SetValue(IsInShiftModeProperty, value);
            }
        }

        public bool IsInSymbolMode
        {
            get
            {
                return (bool)GetValue(IsInSymbolModeProperty);
            }
            set
            {
                SetValue(IsInSymbolModeProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.keysGrid = this.GetTemplateChild("PART_KeysGrid") as Grid;
            this.shiftButton = this.GetTemplateChild("PART_ShiftButton") as Button;
            this.symbolButton = this.GetTemplateChild("PART_SymbolButton") as Button;
            this.spaceButton = this.GetTemplateChild("PART_SpaceButton") as Button;
            this.backspaceButton = this.GetTemplateChild("PART_BackspaceButton") as Button;
            this.enterButton = this.GetTemplateChild("PART_EnterButton") as Button;

            if (keysGrid == null)
            {
                throw new InvalidOperationException("Cannot find PART_KeysGrid.");
            }

            if (shiftButton == null)
            {
                throw new InvalidOperationException("Cannot find PART_ShiftButton.");
            }

            if (symbolButton == null)
            {
                throw new InvalidOperationException("Cannot find PART_SymbolButton.");
            }

            if (spaceButton == null)
            {
                throw new InvalidOperationException("Cannot find PART_SpaceButton.");
            }

            if (backspaceButton == null)
            {
                throw new InvalidOperationException("Cannot find PART_BackspaceButton.");
            }

            if (enterButton == null)
            {
                throw new InvalidOperationException("Cannot find PART_EnterButton.");
            }

            this.shiftButton.Click += OnShiftButtonClick;
            this.symbolButton.Click += OnSymbolButtonClick;
            this.spaceButton.Click += OnSpaceButtonClick;
            this.backspaceButton.Click += OnBackspaceButtonClick;
            this.enterButton.Click += OnEnterButtonClick;

            this.keyboardContext = this.GenerateKeyboardContext();
            this.secondaryKeybordContext = this.GenerateSecondaryKeyboardContext();
            this.GenerateKeyboard(this.keyboardContext);
        }

        public Expression Expression
        {
            get
            {
                return this._expression;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Expression cannot be null");
                }

                if (ReferenceEquals(value, this.Expression))
                {
                    return;
                }

                this._expression = value;
            }
        }

        protected abstract KeyboardContext GenerateKeyboardContext();
        protected abstract KeyboardContext GenerateSecondaryKeyboardContext();

        protected virtual void DoInShiftModeChanged()
        {
            if (this.IsInSymbolMode && this.IsInShiftMode)
            {
                this.IsInSymbolMode = false;
            }

            this.ChangeCase(this.IsInShiftMode);
        }

        protected virtual void DoInSymbolModeChanged()
        {
            if (this.IsInSymbolMode && this.IsInShiftMode)
            {
                this.IsInShiftMode = false;
            }

            this.GenerateKeyboard(this.IsInSymbolMode ? this.secondaryKeybordContext : this.keyboardContext);
        }

        protected virtual void RaiseKeyClicked(KeyEventArgs e)
        {
            EventHandler<KeyEventArgs> handler = this.KeyClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void RaiseSpaceKeyClicked(EventArgs e)
        {
            EventHandler handler = this.SpaceKeyClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void RaiseBackspaceButtonClicked(EventArgs e)
        {
            EventHandler handler = this.BackspaceKeyClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void RaiseEnterKeyClicked(EventArgs e)
        {
            EventHandler handler = this.EnterKeyClicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnShiftButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInShiftMode = this.IsInShiftMode == false;
        }

        private void OnSymbolButtonClick(object sender, RoutedEventArgs e)
        {
            this.IsInSymbolMode = this.IsInSymbolMode == false;
        }

        private static void OnInShiftModeChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            Keyboard keyboard = sender as Keyboard;
            if (keyboard == null)
            {
                return;
            }

            keyboard.DoInShiftModeChanged();
        }

        private static void OnInSymbolModeChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            Keyboard keyboard = sender as Keyboard;
            if (keyboard == null)
            {
                return;
            }

            keyboard.DoInSymbolModeChanged();
        }

        private void ChangeCase(bool toUpper)
        {
            foreach (UIElement uiElement in this.keysGrid.Children)
            {
                StackPanel stackPanel = uiElement as StackPanel;
                if (stackPanel == null)
                {
                    continue;
                }

                foreach (UIElement element in stackPanel.Children)
                {
                    Button button = element as Button;

                    if (ToUpperReplacement == null)
                    {
                        if (button != null && button.Content != null)
                        {
                            button.Content = toUpper
                                                 ? button.Content.ToString().ToUpper()
                                                 : button.Content.ToString().ToLower();
                        }
                    }
                    else
                    {
                        if (toUpper)
                        {
                            if (ToUpperReplacement.ContainsKey(button.Content.ToString()))
                            {
                                button.Content = ToUpperReplacement[button.Content.ToString()];
                            }
                        }
                        else
                        {
                            foreach (var key in ToUpperReplacement.Keys)
                            {
                                if (ToUpperReplacement[key] == button.Content.ToString())
                                {
                                    button.Content = key;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void GenerateKeyboard(KeyboardContext context)
        {
            // Build grid
            this.keysGrid.Children.Clear();
            this.keysGrid.RowDefinitions.Clear();
            this.keysGrid.ColumnDefinitions.Clear();

            for (int row = 0; row < context.Rows; row++)
            {
                this.keysGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });

                StackPanel insideGrid = new StackPanel
                                        {
                                            HorizontalAlignment = HorizontalAlignment.Center,
                                            Orientation = Orientation.Horizontal
                                        };
                Grid.SetRow(insideGrid, row);
                keysGrid.Children.Add(insideGrid);

                List<KeyMapping> keyMappings = context.KeyboardMapping.GetKeyMappingsByRow(row);
                foreach (KeyMapping keyMapping in keyMappings)
                {
                    KeyboardButton keyboardButton = new KeyboardButton
                    {
                        Content = keyMapping.Symbol
                    };
                    keyboardButton.Click += this.OnKeyButtonClicked;
                    insideGrid.Children.Add(keyboardButton);
                }
            }
        }

        private void OnKeyButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null || button.Content == null)
            {
                return;
            }

            this.RaiseKeyClicked(new KeyEventArgs(this.IsInShiftMode, this.Expression.Interpret(button.Content.ToString())));
        }

        private void OnSpaceButtonClick(object sender, RoutedEventArgs e)
        {
            this.RaiseSpaceKeyClicked(EventArgs.Empty);
        }

        private void OnBackspaceButtonClick(object sender, RoutedEventArgs e)
        {
            this.RaiseBackspaceButtonClicked(EventArgs.Empty);
        }

        private void OnEnterButtonClick(object sender, RoutedEventArgs e)
        {
            this.RaiseEnterKeyClicked(EventArgs.Empty);
        }

    }
}
