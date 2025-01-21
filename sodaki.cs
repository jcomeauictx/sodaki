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
/box {  % width -
  % arc takes args: x y r angle0 angle1 (in degrees)
  gsave
  (drawing box at ) #only currentpoint exch #only (, ) #only #
  3 dict begin
  /boxwidth exch def
  /radius 10 def 
  /side boxwidth radius dup add sub def  % straight part of side
  /spacing radius 2 div def
  spacing radius add 0 rmoveto
  side 0 rlineto  % bottom line
  currentpoint exch spacing add exch radius add radius -90 0 arc
  0 side rlineto
  currentpoint exch radius sub exch radius 0 90 arc
  side neg 0 rlineto
  currentpoint radius sub radius 90 180 arc
  0 side neg rlineto
  currentpoint exch radius add exch radius 180 270 arc closepath fill
  grestore
  end
  (stack at end of box: ) #only #stack
} bind def
/boxrow {  % boxwidth boxes -
  2 dict begin
  /boxes exch def
  /boxwidth exch def
  boxes {boxwidth box boxwidth 0 rmoveto} repeat
  end
  (stack at end of boxrow: ) #only #stack
} bind def
scriptname (sodaki) eq {
  /margin 20 def  % minimum margin in pixels
  /rowlength 4 def  % boxes in a row
  /TimesNewRoman-Bold 80 selectfont
  0 pageheight 80 sub moveto (SODAKI) centershow
  /TimesNewRoman-Bold 20 selectfont
  0 -20 rmoveto (A language for systems thinking) centershow
  % draw a grid pagewidth x pagewidth, of black squares with some missing
  % leave 20 pixels at bottom for author name
  currentpoint 20 sub exch pop  % page height remaining
  pagewidth dup
  dup margin dup add sub rowlength div exch
  margin exch neg #stack rmoveto 4 boxrow
  (stack at end of sodaki: ) #only #stack
  showpage
} if
% vim: tabstop=8 shiftwidth=2 softtabstop=2 syntax=postscr
