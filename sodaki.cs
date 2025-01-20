#!/usr/local/casperscript/bin/cs --
/centershow {
  dup false charpath pathbbox #stack
} bind def
scriptname (sodaki) eq {
  /TimesNewRoman-Bold 40 selectfont
  0 pageheight 40 sub moveto (SODAKI) centershow
} if
% vim: tabstop=8 shiftwidth=2 softtabstop=2 syntax=postscr
