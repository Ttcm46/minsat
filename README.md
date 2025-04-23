# Minsat
*Minsat* is a simple console application that aims to simplify the process of making SAT(Mexico) tax declarations, it doesnt do the process for you, but it simplifies it.

*Minsat* ***DOES NOT*** replace an accountant or claims to do your taxes, its just a tool meant to make the proccess easier.
I/we fully encourage you to do your taxes on time and in an orderly manner so as to not get in trouble.

## Using minsat
As of right now the functionality is quite limited.
But *Minsat* offers the following:
- Summary of XML reciepts

The use of Minsat is quite simple as its made as a console application for all platforms.
To call *Minsat* and its functionalities:
```bash
minsat [options] ...
```
### Summary of reciepts

You can either just call *Minsat* in the directory and it will summarize the xml SAT reciepts in it.
```bash
minsat
```
Or you can specify the path of the directory.
**NOTE:** This is most likely to changhe in the future so as to make a more conscise, ordered and expanded command options repertoire
```bash
minsat summarize [options]
```
this option currently can export to:
- csv

to export use
```
minsat summarize -e [(optional)File type(currently only csv)] [(optional) path]
```
it will export by default to the current directory in a csv format

## Future plans
In the future I/we(hopefully) plan to add the following:
- ability to export the summaries to JSON, excel, xml, ...
- more detailed summaries
- Full year summaries