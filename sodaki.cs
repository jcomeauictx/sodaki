#!/usr/local/casperscript/bin/cs --
/centershow {
  gsave
    dup false charpath pathbbox pop #stack  % pop yt, we only need xl and xr
    3 -1 roll sub #stack exch pop  % discard yb
    pagewidth exch sub 2 div #stack
  grestore
  gsave
    currentpoint exch pop moveto show
  grestore
} bind def
/grid {
} bind def
/box {
  gsave
  3 dict begin
  /boxwidth exch def
  /radius 10 def
  /spacing radius 2 div def
  spacing 0 rmoveto boxwidth spacing sub 0 rlineto  % bottom line
  currentpoint exch spacing add exch radius 0 90 arc stroke
  grestore
  end
} bind def
scriptname (sodaki) eq {
  /TimesNewRoman-Bold 80 selectfont
  0 pageheight 80 sub moveto (SODAKI) centershow
  /TimesNewRoman-Bold 20 selectfont
  0 -20 rmoveto (A language for systems thinking) centershow
  % draw a grid pagewidth x pagewidth, of black squares with some missing
  % leave 20 pixels at bottom for author name
  currentpoint 20 sub exch pop  % page height remaining
  pagewidth min #stack
  dup .8 mul 4 div exch
  0 exch #stack rmoveto box
  showpage
} if
% vim: tabstop=8 shiftwidth=2 softtabstop=2 syntax=postscr
