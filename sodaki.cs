#!/usr/local/casperscript/bin/cs --
/centershow {
  gsave
    dup false charpath pathbbox pop #stack  % pop yt, we only need xl and xr
    3 -1 roll sub #stack exch pop  % discard yb
    pagewidth exch sub 2 div #stack
  grestore
  currentpoint exch pop moveto show
} bind def
scriptname (sodaki) eq {
  /TimesNewRoman-Bold 80 selectfont
  0 pageheight 80 sub moveto (SODAKI) centershow
  showpage
} if
% vim: tabstop=8 shiftwidth=2 softtabstop=2 syntax=postscr
