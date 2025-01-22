SHELL := /bin/bash
CASPER_INIT := $(wildcard ../casperscript/Resource/Init)
test: sodaki.cs
	./$<
edit: sodaki.cs
	vi $+
push:
	git push -u origin master
	git push -u githost master
bookcover.pdf: sodaki.cs .FORCE
	tail -n +2 $< | gs -sDEVICE=pdfwrite -o $@ -
bookcover.png: bookcover.pdf
	convert $< -background white -alpha remove $@
.FORCE:
