﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALFC_SOAP.Entities;

namespace ALFC_SOAP.Data
{
    class BibleInfo
    {
        string bible = "Genesis, Hebrew, 50; Exodus, Hebrew, 40; Leviticus, Hebrew, 27; Numbers, Hebrew, 36; Deuteronomy, Hebrew, 34; Joshua , Hebrew, 24; Judges, Hebrew, 21; Ruth, Hebrew, 4; 1 Samuel, Hebrew, 31; 2 Samuel, Hebrew, 24; 1 Kings , Hebrew, 22; 2 Kings , Hebrew, 25; 1 Chronicles, Hebrew, 29; 2 Chronicles, Hebrew, 36; Ezra , Hebrew and Aramaic, 10; Nehemiah, Hebrew, 13; Esther, Hebrew, 10; Job, Hebrew, 42; Psalms, Hebrew, 150; Proverbs, Hebrew, 31; Ecclesiastes, Hebrew, 12; Song of Solomon, Hebrew, 66; Isaiah, Hebrew, 66; Ezekiel, Hebrew, 48; Daniel, Hebrew and Aramaic, 12; Hosea, Hebrew, 14; Joel, Hebrew, 3; Amos, Hebrew, 9; Obadiah, Hebrew, 1; Jonah, Hebrew, 4; Micah, Hebrew, 7; Nahum, Hebrew, 3; Habakkuk, Hebrew, 3; Zephaniah, Hebrew, 3; Haggai, Hebrew, 2; Zechariah, Hebrew, 14; Malachi, Hebrew, 4; Matthew, Greek, 28; Mark, Greek, 16; Luke, Greek, 24; John, Greek, 21;Acts, Greek, 28; Romans, Greek, 16; 1 Corinthians, Greek, 16; 2 Corinthians, Greek, 13; Galatians, Greek, 6; Ephesians, Greek, 6; Phillippians, Greek, 4; Colossians, Greek, 4; 1 Thessalonians, Greek, 5; 2 Thessalonians, Greek, 3; 1 Timothy, Greek, 6; 2 Timothy, Greek, 4; Titus, Greek, 3; Philemon, Greek, 1; Hebrews, Greek, 13; James, Greek, 5; 1 Peter, Greek, 5; 2 Peter, Greek, 3;1 John, Greek, 5; 2 John, Greek, 1; 3 John, Greek, 1; Revelation, Greek, 22";
        string[] books;
        public List<Book> BibleBooks { get; private set; }

        public BibleInfo()
        {
            books = bible.Split(';');
            BibleBooks = BuildBookList();
        }

        private List<Book> BuildBookList()
        {
            List<Book> booklist = new List<Book>();

            for (int i = 0; i < books.Length; i++)
            {
                string[] bookinfo = books[i].Split(',');
                booklist.Add(new Book(bookinfo[0], bookinfo[1], int.Parse(bookinfo[2])));
            }

            return booklist;
        }
    }
}
