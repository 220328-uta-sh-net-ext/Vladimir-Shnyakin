**Linux**, computer <ins>operating system</ins> created in the early 1990s by Finnish software engineer Linus Torvalds and the Free Software Foundation (FSF).

While still a student at the University of Helsinki, Torvalds started developing Linux to create a system similar to MINIX, a UNIX operating system. In 1991 he released version 0.02; Version 1.0 of the Linux kernel, the core of the operating system, was released in 1994. About the same time, American software developer Richard Stallman and the FSF made efforts to create an open-source UNIX-like operating system called GNU. In contrast to Torvalds, Stallman and the FSF started by creating utilities for the operating system first. These utilities were then added to the Linux kernel to create a complete system called GNU/Linux, or, less precisely, just Linux.

Linux grew throughout the 1990s because of the efforts of hobbyist developers. Although Linux is not as user-friendly as the popular Microsoft Windows and Mac OS operating systems, it is an efficient and reliable system that rarely crashes. Combined with Apache, an open-source Web server, Linux accounts for most of the servers used on the Internet. Because it is open-source, and thus modifiable for different uses, Linux is popular for systems as diverse as cellular telephones and supercomputers. Android, Google’s operating system for mobile devices, has at its core a modified Linux kernel, and Chrome OS, Google’s operating system that uses the Chrome browser, is also Linux-based. The addition of user-friendly desktop environments, office suites, Web browsers, and even games helped to increase Linux’s popularity and make it more suitable for home and office desktops. New distributions (packages of Linux software) have been created since the 1990s. Some of the more well-known distributions include MX Linux, Manjaro, Linux Mint, and Ubuntu.

**Information source** [
Linux operating system
By The Editors of Encyclopaedia Britannica 
](https://www.britannica.com/technology/Linux)

## What is a Unix Shell?

A Unix shell is a <ins>**command-line interpreter**</ins> that’s interprets the command entered by the user. We enter a command and then it interprets that command and gives us the output of that command. A shell provides a traditional user interface for the Unix operating system and for Unix-like systems that we all are used to. Usually, black screen with a white text color. Users enter commands as plain text or we can create text scripts of one or more commands all together one after another.

<ins>The shell is your *interface* to the operating system.</ins> The way user can interact with the system. After you login to the Unix system, you are placed in a program which is called the shell.

<details><summary>Thompson Shell</summary>
<p>
According to history and many online materials, the very first Unix shell was the Thompson shell, sh, written by **Ken Thompson** at Bell Labs (The very famous Bell Labs). It was distributed with Versions 1 through 6 of Unix, from 1971 to 1975. It has features like piping, simple control structures using if and goto, and filename wildcarding. Now a days, it is not coming with modern Unix / Linux systems.
</p>
</details>

<details><summary>The PWB Shell</summary>
<p>
The PWB shell or Mashey shell, sh, was an updated version (it was a modified version) of the Thompson shell, written by **John Mashey**. It was written for encouraging shell programming. Some great features like if-then-else-endif, and switch and while constructs were introduced in this shell.
</p>
</details>

<details><summary>The Bourne Shell</summary>
<p>
  
The rise of Unix began with the Bourne shell. The Bourne shell, sh, was writen by **Stephen Bourne** at Bell Labs. And it gets distributed as the shell for UNIX Version 7 from 1979.

It has many basic features and later on those are inherited to many other Unix Shell like here documents, command substitution, more generic variables and built in control structures. Bourne shell program name is “sh” and its path in the Unix file system hierarchy is /bin/sh.

On many systems, Bourne Shell (sh) may be a symbolic link or hard link to one of these alternatives shell mentioned below

 - Almquist shell (ash)
 - Bourne-Again shell (bash)
 - Korn shell (ksh)
 - Z shell (zsh)

  <details><summary>A Simple Bourne Shell Example</summary>
  <p>
  
  ```#!/bin/sh
  echo "Hello World 1!"
  echo "Hello World 2!"
  ```
   
  </p>
  </details>
</p>
</details>

<details><summary>Almquist shell (ash)</summary>
<p>

The Almquist shell is also known as A Shell, ash and sh. It’s a lightweight Unix shell originally written by **Kenneth Almquist**. It was written in the late 1980s. It’s a variant of the Bourne shell, and it replaced the original Bourne shell in the BSD versions of Unix released in the early 1990s. In some modern Linux distributions like Debian and Debian derived Linux distributions such as Ubuntu ship a version of ash, known as dash (Debian Almquist shell). Ash is also fairly popular in embedded Linux systems.

It is fast, small, and compatible with the POSIX standard’s specification of the Unix shell and may be that’s why it is being used on embedded devices. Ash did not supports command history mechanisms. However, few current variants of Ash Shell may support it.
</p>
</details>

<details><summary>Bourne-Again shell</summary>
<p>

Written by Brian Fox for the GNU Project as a free software replacement for the Bourne shell. Most popular and widely used among all of the shells. Every Linux distribution comes up with this shell. It provides a superset of Bourne Shell functionality. On most of the GNU/Linux distribution, this shell can be found installed and is the default interactive shell for users with /bin/bash path location. This is released in the year 1989.

Due to it’s popularity, it has been ported to Microsoft Windows and distributed with Cygwin and MinGW to serve the bash functionalities. For Android, via various terminal emulation applications.

It supports wildcard matching, piping, here documents, command substitution, variables and control structures for condition-testing (If – then – else if) and iteration (loop).

Bash scripts starts with the following syntax:

```
  #!/bin/bash
```
Bash shell can also read commands from a file and can redirect the output to a file-using pipeline as well.
  <details><summary>A Simple Bourne-Again Shell Example</summary>
  <p>

  ```
  #!/bin/sh
  if [ $days -gt 365 ]
  then
  echo This is over a year.
  fi
  ```
  </p>
  </details>
</p>
</details>

<details><summary>Korn shell (ksh)</summary>
<p>
  
Written by **David Korn** based on the Bourne shell sources. KornShell (ksh) is a Unix shell, which was developed & written by David Korn at Bell Labs in the early 1980s. As mentioned earlier, the initial development was based on Bourne shell source code. KornShell is backward-compatible with the Bourne shell.Also it includes many features of the C shell as well.

It has following variants

  - Dtksh
  - Tksh
  - Oksh
  - Mksh
  - Sksh
  - MKS Korn shell

  <details><summary>A Simple Korn Shell (ksh) Example</summary>
  <p>
  
  ```
  #!/bin/ksh
  print Disk space usage
  du -k
  exit 0
  ```
  </p>
  </details>
</p>
</details>

<details><summary>Z shell (zsh)</summary>
<p>

**Paul Falstad** wrote the first version of Zsh Shell in 1990. The Z shell (zsh) is a Unix shell that can be used as an interactive login shell and very powerful command interpreter for shell scripting as well. Actually, Zsh is an extended Bourne shell with a large number of improvements, which includes some features from bash, ksh, and tcsh.

The name Zsh derives from the name of Yale professor Zhong Shao as Paul Falstad was a student at Princeton University.

It has some good features like

  - Programmable command-line completion (Auto Completion).
  - Sharing of command history among all running shells.
  - Extended file globbing.
  - Improved variable or array handling.
  - Editing of multi-line commands in a single buffer.
  - Spelling correction and lot others.
</p>
</details>
<details><summary>C shell</summary>
<p>

The C shell is also known as Csh. While **Bill Joy** was a graduate student at University of California, he wrote C Shell. It is widely distributed with BSD Unix. It has some great features including the control structures and the expression grammar. The C shell also introduced a large number of new features for interactive work which includes history and editing mechanisms. Also aliases, cdpath, job control and path hashing, I/O redirection, joining, variable substitution, background execution etc.

Like all other Unix shells, it supports wildcard of filename, command piping, variables and control structures for condition-testing and iteration. csh is actually tcsh on many systems like as Mac OS X and Red Hat Linux. Tcsh is a improved version of Csh. But On Debian and some derivatives (including Ubuntu from Debian), there are two different packages: csh and tcsh.

<details><summary>A Simple C Shell Example</summary>
<p>

```
#!/bin/csh
if ( $days > 365 ) then
echo This is over a year.
endif
```
</p>
</details>
</p>
</details>

**Information source** [
Evolution Of Unix / Linux Shells
By Mohammad Forhad Iftekher
](https://www.unixmen.com/evolution-unix-linux-shells/)


## Shell Scripting

• A script is simply a collection of commands that
are intended to run as a group.

• Commands may or may not be dependent on
each other.

• Variables, hence their values, can be
transferred from one command to another.

• Supports complex choices and logic.

• A script is always executed in its own shell.

<details><summary>Example Shell Script 1</summary>
<p>
  
```Hello world!
#!/bin/bash
# This is our first shell script!!
echo “Hello World!”
```
</p>
</details>

### Variables in Shell Scripting
• Variables are containers that store a value.

• All variables created in a script are shell
variables.

• A script can access the environment variables
in addition to its own shell variables.

• Variable can store any kind of value ie., string
or integer or floating point number etc.

<details><summary>Examples</summary>
<p>
  
```INT=1
FLOAT=1.5
STR=hello
STR2=“hello world”
RND=asdf2341.sfe
echo $INT
echo “Value of FLOAT is $FLOAT”
echo “$STR is a string”
echo “$RND is non-sensical”
```
</p>
</details>
<details><summary>Example Shell Script 2</summary>
<p>
  
```• Second example script: lsScr.sh
#!/bin/bash
# List contents of scratch
cd $RCAC_SCRATCH
ls –l
• Make script executable, place it in PATH.
```
</p>
</details>

### Special shell variables
• Special Variables
 - $# = No. of parameters given to script

 - $@ = List of parameters given to script

 - $0 = Name of current program (script)

 - $1, $2.. = Parameter 1, 2 and so on..

 - $? = Exit value of last command run

• These variables are shell variables and only
valid to the current shell.

#### Even more special characters
• * matches every character, just as in regular
expressions.

• So, ls *txt in a script will list all files whose
name ends in txt.

• \ is an escape character which tells the shell to
not interpret the character after it.

• \ is commonly used to escape the special
characters such as *, $ etc.

<details><summary>Example Shell Script 3</summary>
<p>
  
```
#!/bin/bash
# List contents of scratch
echo “Executing script : \”$0\” with $#
parameters”
cd $RCAC_SCRATCH
ls –l
• Make script executable, place it in PATH.
```
  </p>
</details>

**Information source** [
Shell scripting and
system variables
HORT 59000
Lecture 5
Instructor: Kranthi Varala
](https://www.purdue.edu/hla/sites/varalalab/wp-content/uploads/sites/20/2018/02/Lecture_5.pdf)

