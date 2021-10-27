/*
 *  File Name:   AboutWindow.xaml.cs
 *
 *  Project:     GUI_Client
 *
 *  Copyright (c) 2021 Bradley Willcott
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * ****************************************************************
 * Name: Bradley Willcott
 * ID:   M198449
 * Date: 27/10/2021
 * ****************************************************************
 */

namespace GUIClient
{
    using System;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        private const String COPYRIGHT
            = "    This program is free software: you can redistribute it and/or "
            + "modify it under the terms of the GNU General Public License as "
            + "published by the Free Software Foundation, either version 3 of "
            + "the License, or (at your option) any later version.\n\n"
            + "    This program is distributed in the hope that it will be useful, "
            + "but WITHOUT ANY WARRANTY; without even the implied warranty of "
            + "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU "
            + "General Public License for more details.\n\n"
            + "    You should have received a copy of the GNU General Public "
            + "License along with this program.  If not, see\n"
            + "<http://www.gnu.org/licenses/>.";

        private const String COPYRIGHT_NOTICE
                = "Copyright (c) 2021 Bradley Willcott";

        private const String DESCRIPTION
                = "This program was developed for my Diploma in Software Development "
                + "at the South Metropolitan TAFE, Rockingham WA.\n\n"
                + "This application uses an external 3rd party library to read and "
                + "write data to a CSV format.  The program has an open and save dialog box "
                + "interface so a file can be selected and displayed in a table.";

        public AboutWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;

            productLabel.Content = Constants.PRODUCT_TITLE;
            verionLabel.Content = Constants.VERSION;
            buildDateLabel.Content = Constants.BUILD_DATE;
            copyrightLabel.Content = COPYRIGHT_NOTICE;

            // Display the Product Description
            FlowDocument doc = new();
            doc.PagePadding = new Thickness(5);

            Paragraph p = new(new Run(DESCRIPTION));
            doc.Blocks.Add(p);
            descriptionViewer.Document = doc;

            // Display the Copyright notice
            doc = new();
            doc.PagePadding = new Thickness(5);
            p = new(new Run(COPYRIGHT));
            doc.Blocks.Add(p);
            copyrightViewer.Document = doc;
        }
    }
}