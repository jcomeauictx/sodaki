SHELL := /bin/bash
GS ?= cs
test: sodaki.cs
	./$<
edit: sodaki.cs
	vi $+
push:
	git push -u origin master
	git push -u githost master
cover: bookcover.png
bookcover.pdf: sodaki.cs .FORCE
	cs -sDEVICE=pdfwrite -sstdout=%stderr -o $@ $<
bookcover.png: bookcover.pdf
	convert $< -background white -alpha remove $@
clean:
	git clean -x -f
.FORCE:
