using System;
using System.Windows;
using System.Windows.Controls;

namespace WP8.Keyboard.Controls
{
    public class KeyboardScreenControl : Control
    {
        public const string SpaceSymbol = " ";
        public static readonly DependencyProperty KeyboardProperty =
            DependencyProperty.Register( "Keyboard", typeof( Keyboard ), typeof( KeyboardScreenControl ), new PropertyMetadata( OnKeyboardChanged ) );
        public static readonly DependencyProperty OutputControlProperty =
            DependencyProperty.Register( "OutputControl", typeof( IOutputControl ), typeof( KeyboardScreenControl ), new PropertyMetadata( OnOutputControlChanged ) );
        public static readonly DependencyProperty OutputReadControlProperty =
            DependencyProperty.Register( "OutputReadControl", typeof( IOutputControl ), typeof( KeyboardScreenControl ), new PropertyMetadata( OnOutputReadControlChanged ) );

        public KeyboardScreenControl()
        {
            this.DefaultStyleKey = typeof( KeyboardScreenControl );
        }

        public Keyboard Keyboard
        {
            get
            {
                return ( Keyboard )GetValue( KeyboardProperty );
            }
            set
            {
                SetValue( KeyboardProperty, value );
            }
        }

        public IOutputControl OutputControl
        {
            get
            {
                return ( IOutputControl )GetValue( OutputControlProperty );
            }
            set
            {
                SetValue( OutputControlProperty, value );
            }
        }

        public IOutputControl OutputReadControl
        {
            get
            {
                return ( IOutputControl )GetValue( OutputControlProperty );
            }
            set
            {
                SetValue( OutputControlProperty, value );
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.OutputControl = new DefaultScreenControl();
            this.OutputReadControl = new DefaultScreenControl();
        }

        private static void OnKeyboardChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            if ( e.NewValue == null )
            {
                throw new ArgumentNullException( "e", "KeyboardControl cannot be null." );
            }

            KeyboardScreenControl sender = d as KeyboardScreenControl;
            if ( sender == null )
            {
                return;
            }

            sender.Keyboard.KeyClicked -= sender.OnKeyboardKeyClicked;
            sender.Keyboard.KeyClicked += sender.OnKeyboardKeyClicked;
            sender.Keyboard.SpaceKeyClicked -= sender.OnSpaceKeyClicked;
            sender.Keyboard.SpaceKeyClicked += sender.OnSpaceKeyClicked;
            sender.Keyboard.BackspaceKeyClicked -= sender.OnBackspaceKeyClicked;
            sender.Keyboard.BackspaceKeyClicked += sender.OnBackspaceKeyClicked;
            sender.Keyboard.EnterKeyClicked -= sender.OnEnterKeyClicked;
            sender.Keyboard.EnterKeyClicked += sender.OnEnterKeyClicked;
        }

        private static void OnOutputControlChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            if ( e.NewValue == null )
            {
                throw new ArgumentNullException( "e", "OutputControl cannot be null." );
            }
        }

        private static void OnOutputReadControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void OnKeyboardKeyClicked( object sender, KeyEventArgs e )
        {
            this.OutputControl.AppendToText( e.Symbol );
        }

        private void OnSpaceKeyClicked( object sender, EventArgs e )
        {
            this.OutputControl.AppendToText( KeyboardScreenControl.SpaceSymbol );
        }

        private void OnBackspaceKeyClicked( object sender, EventArgs e )
        {
            this.OutputControl.RemoveLast();
        }

        private void OnEnterKeyClicked( object sender, EventArgs e )
        {
            this.OutputControl.AppendToText( Environment.NewLine );
        }
    }
}
