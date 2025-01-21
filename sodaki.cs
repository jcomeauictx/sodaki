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
/box {  % boxwidth -
  % arc takes args: x y r angle0 angle1 (in degrees)
  gsave
  (drawing ) #only dup #only ( pixel box at ) #only
  currentpoint exch #only (, ) #only #
  2 dict begin
  /boxwidth exch def
  /side boxwidth radius dup add sub spacing sub def  % straight part of side
  radius spacing add 0 rmoveto
  4 {
    side 0 rlineto
    % position x and y for curved corner
    currentpoint radius add
    radius -90 0 arc
    90 rotate
  } repeat
  closepath fill
  grestore
  end
  (stack at end of box: ) #only #stack
} bind def
/boxrow {  % boxwidth -
  1 dict begin
  /boxwidth exch def
  spacing 0.5 mul neg 0 rmoveto  % ensures even margins
  rowlength {boxwidth box boxwidth 0 rmoveto} repeat
  end
  (stack at end of boxrow: ) #only #stack
} bind def
/boxrows {  % boxwidth rows -
  (stack at start of boxrows: ) #only #stack
  {gsave dup boxrow grestore 0 1 index rmoveto}
  repeat pop  % discard boxwidth at end of loop
} bind def
scriptname (sodaki) eq {
  /margin 20 def  % minimum margin in pixels
  /rowlength 4 def  % boxes in a row
  /radius margin 2 div def  % radius of curved corners
  /spacing margin 2 div def
  /TimesNewRoman-Bold 80 selectfont
  0 pageheight 80 sub moveto (SODAKI) centershow
  /TimesNewRoman-Bold 20 selectfont
  0 -20 rmoveto (A language for systems thinking) centershow
  % draw a grid pagewidth x pagewidth, of black squares with some missing
  % leave 20 pixels at bottom for author name
  currentpoint 20 sub exch pop  % page height remaining
  pagewidth dup margin dup add sub rowlength div exch
  margin exch neg rmoveto exch 1 index #stack div cvi #stack boxrows
  (stack at end of sodaki: ) #only #stack
  0 margin moveto (John Otis Comeau) centershow
  showpage
} if
% vim: tabstop=8 shiftwidth=2 softtabstop=2 syntax=postscr
