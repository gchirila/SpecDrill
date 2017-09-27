Û
sD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Configuration\BrowserWindowConfiguration.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
." #
Configuration# 0
{ 
public		 

class		 &
BrowserWindowConfiguration		 +
{

 
public 
bool 
IsMaximized 
{  !
get" %
;% &
set' *
;* +
}, -
public 
int 
? 
InitialWidth  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
int 
? 
InitialHeight !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} °6
mD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Configuration\ConfigurationManager.cs
	namespace

 	
	SpecDrill


 
.

 
Infrastructure

 "
.

" #
Configuration

# 0
{ 
public 

class  
ConfigurationManager %
{ 
private 
const 
string !
ConfigurationFileName 2
=3 4
$str5 K
;K L
	protected 
static 
Logging  
.  !

Interfaces! +
.+ ,
ILogger, 3
Log4 7
;7 8
public 
static 
readonly 
Settings '
Settings( 0
;0 1
static  
ConfigurationManager #
(# $
)$ %
{ 	
Settings 
= 
Load 
( 
) 
; 
Log 
= 
Logging 
. 
Log 
. 
Get !
<! " 
ConfigurationManager" 6
>6 7
(7 8
)8 9
;9 :
} 	
public 
static 
Settings 
Load #
(# $
string$ *
jsonConfiguration+ <
== >
null? C
)C D
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
jsonConfiguration* ;
); <
)< =
{ 
Log 
. 
Info 
( 
$" )
Searching Configuration file  8
{8 9!
ConfigurationFileName9 N
}N O
...O R
"R S
)S T
;T U
var 
configurationPaths &
=' (!
FindConfigurationFile) >
(> ?
	AppDomain? H
.H I
CurrentDomainI V
.V W
BaseDirectoryW d
)d e
;e f
if 
( 
configurationPaths &
==' )
null* .
). /
throw   
new   !
FileNotFoundException   3
(  3 4
$str  4 R
)  R S
;  S T
var"" !
configurationFilePath"" )
=""* +
configurationPaths"", >
.""> ?
Item1""? D
;""D E
var## !
log4netConfigFilePath## )
=##* +
Path##, 0
.##0 1
Combine##1 8
(##8 9!
configurationFilePath##9 N
,##N O
$str##P `
)##` a
;##a b
var%% 
log4NetConfig%% !
=%%" #
new%%$ '
FileInfo%%( 0
(%%0 1!
log4netConfigFilePath%%1 F
)%%F G
;%%G H
XmlConfigurator'' 
.''  
	Configure''  )
('') *
log4NetConfig''* 7
)''7 8
;''8 9
var)) %
jsonConfigurationFilePath)) -
=)). /
configurationPaths))0 B
.))B C
Item2))C H
;))H I
if++ 
(++ 
string++ 
.++ 
IsNullOrWhiteSpace++ -
(++- .%
jsonConfigurationFilePath++. G
)++G H
)++H I
{,, 
Log-- 
.-- 
Info-- 
(-- 
$str-- <
)--< =
;--= >
throw.. 
new.. !
FileNotFoundException.. 3
(..3 4
$str..4 R
)..R S
;..S T
}// 
jsonConfiguration11 !
=11" #
File11$ (
.11( )
ReadAllText11) 4
(114 5%
jsonConfigurationFilePath115 N
)11N O
;11O P
}22 
var33 
configuration33 
=33 
JsonConvert33! ,
.33, -
DeserializeObject33- >
<33> ?
Settings33? G
>33G H
(33H I
jsonConfiguration33I Z
)33Z [
;33[ \
return77 
configuration77  
;77  !
}88 	
private:: 
static:: 
Tuple:: 
<:: 
string:: #
,::# $
string::% +
>::+ ,!
FindConfigurationFile::- B
(::B C
string::C I
folder::J P
)::P Q
{;; 	
while<< 
(<< 
true<< 
)<< 
{== 
Log>> 
.>> 
Info>> 
(>> 
$">> 
	Scanning >> $
{>>$ %
folder>>% +
}>>+ ,
...>>, /
">>/ 0
)>>0 1
;>>1 2
ifAA 
(AA 
folderAA 
.AA 
LengthAA !
>AA" #
$numAA$ %
)AA% &
{BB 
varCC 
resultCC 
=CC  
	DirectoryCC! *
.CC* +
EnumerateFilesCC+ 9
(CC9 :
folderCC: @
,CC@ A
$strCCB J
,CCJ K
SearchOptionCCL X
.CCX Y
TopDirectoryOnlyCCY i
)CCi j
.CCj k
FirstOrDefaultCCk y
(CCy z
fileCCz ~
=>	CC Å
file
CCÇ Ü
.
CCÜ á
ToLowerInvariant
CCá ó
(
CCó ò
)
CCò ô
.
CCô ö
EndsWith
CCö ¢
(
CC¢ £#
ConfigurationFileName
CC£ ∏
.
CC∏ π
ToLowerInvariant
CCπ …
(
CC…  
)
CC  À
)
CCÀ Ã
)
CCÃ Õ
;
CCÕ Œ
ifEE 
(EE 
!EE 
stringEE 
.EE  
IsNullOrWhiteSpaceEE  2
(EE2 3
resultEE3 9
)EE9 :
)EE: ;
{FF 
LogGG 
.GG 
InfoGG  
(GG  !
$"GG! #(
Found configuration file at GG# ?
{GG? @
resultGG@ F
}GGF G
"GGG H
)GGH I
;GGI J
returnHH 
TupleHH $
.HH$ %
CreateHH% +
(HH+ ,
folderHH, 2
,HH2 3
resultHH4 :
)HH: ;
;HH; <
}II 
folderKK 
=KK 
GetParentFolderKK ,
(KK, -
folderKK- 3
)KK3 4
;KK4 5
continueLL 
;LL 
}MM 
returnOO 
nullOO 
;OO 
}PP 
}QQ 	
privateSS 
staticSS 
stringSS 
GetParentFolderSS -
(SS- .
stringSS. 4
folderSS5 ;
)SS; <
{TT 	
returnUU 
folderUU 
.UU 
RemoveUU  
(UU  !
folderUU! '
.UU' (
LastIndexOfUU( 3
(UU3 4
$charUU4 8
)UU8 9
)UU9 :
;UU: ;
}VV 	
}WW 
}XX â
aD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Configuration\Homepage.cs
	namespace 	
	SpecDrill
 
. 
Configuration !
{ 
public		 

class		 
Homepage		 
{

 
public 
string 
PageObjectType $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
Url 
{ 
get 
;  
set! $
;$ %
}& '
public 
bool 
IsFileSystemPath $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} œ
nD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Configuration\SeleniumConfiguration.cs
	namespace 	
	SpecDrill
 
. 
Configuration !
{ 
public 

class "
WebDriverConfiguration '
{ 
public 
string 
BrowserDriversPath (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
string 
BrowserDriver #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public		 
bool		 
IsRemote		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
string

 
SeleniumServerUri

 '
{

( )
get

* -
;

- .
set

/ 2
;

2 3
}

4 5
} 
} ä	
aD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Configuration\Settings.cs
	namespace 	
	SpecDrill
 
. 
Configuration !
{ 
public 

class 
Settings 
{ 
public "
WebDriverConfiguration %
	WebDriver& /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public		 &
BrowserWindowConfiguration		 )
BrowserWindow		* 7
{		8 9
get		: =
;		= >
set		? B
;		B C
}		D E
public 
int 
MaxWait 
{ 
get  
;  !
set" %
;% &
}' (
public 
int  
WaitPollingFrequency '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
Homepage 
[ 
] 
	Homepages #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} ¯
UD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Converters.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
{ 
public		 

static		 
class		 

Converters		 "
{

 
public 
static 
T 
ToEnum 
< 
T  
>  !
(! "
this" &
string' -
	enumValue. 7
)7 8
where 
T 
: 
struct 
{ 	
return 
( 
T 
) 
Enum 
. 
Parse !
(! "
typeof" (
() *
T* +
)+ ,
,, -
	enumValue. 7
)7 8
;8 9
} 	
} 
} ∫
]D:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Enums\BrowserNames.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
." #
Enums# (
{ 
public 

enum 
BrowserNames 
{ 
chrome 
, 
ie 

,
 
firefox 
, 
opera 
, 
safari		 
,		 
appium

 
,

 
seleniumServer 
} 
} œ
RD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Globals.cs
	namespace		 	
	SpecDrill		
 
.		 
Infrastructure		 "
{

 
public 

static 
class 
Globals 
{ 
static 
Globals 
( 
) 
{ 	
Configuration 
=  
ConfigurationManager 0
.0 1
Settings1 9
;9 :
} 	
public 
static 
Settings 
Configuration ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
} 
} Å
eD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Logging\Interfaces\ILogger.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
." #
Logging# *
.* +

Interfaces+ 5
{ 
public 

enum 
LogLevel 
{ 
Info 
, 
Warning 
, 
Debug 
, 
Error #
,# $
Fatal% *
} 
public

 

	interface

 
ILogger

 
{ 
void 
Log 
( 
LogLevel 
level 
,  
object! '
message( /
)/ 0
;0 1
void 
Log 
( 
LogLevel 
level 
,  
string! '
format( .
,. /
params0 6
object7 =
[= >
]> ?
args@ D
)D E
;E F
void 
Log 
( 
LogLevel 
level 
,  
	Exception! *
	exception+ 4
,4 5
object6 <
message= D
)D E
;E F
void 
Log 
( 
LogLevel 
level 
,  
	Exception! *
	exception+ 4
,4 5
string6 <
format= C
,C D
paramsE K
objectL R
[R S
]S T
argsU Y
)Y Z
;Z [
} 
} ø
pD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Logging\Implementation\Log4NetFactory.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
." #
Logging# *
.* +
Implementation+ 9
{ 
internal 
class 
Log4NetFactory !
:" #
ILoggerFactory$ 2
{ 
private 
object 
SyncRoot 
=  !
new" %
object& ,
(, -
)- .
;. /
private 
static 

Dictionary !
<! "
string" (
,( )
ILogger* 1
>1 2
loggers3 :
=; <
new= @

DictionaryA K
<K L
stringL R
,R S
ILoggerS Z
>Z [
([ \
)\ ]
;] ^
public<< 
ILogger<< 
Get<< 
(<< 
string<< !
name<<" &
)<<& '
{== 	
if>> 
(>> 
!>> 
loggers>> 
.>> 
ContainsKey>> $
(>>$ %
name>>% )
)>>) *
)>>* +
{?? 
lock@@ 
(@@ 
SyncRoot@@ 
)@@ 
{AA 
ifBB 
(BB 
!BB 
loggersBB  
.BB  !
ContainsKeyBB! ,
(BB, -
nameBB- 1
)BB1 2
)BB2 3
{CC 
varDD 
log4NetLoggerDD )
=DD* +

LogManagerDD, 6
.DD6 7
	GetLoggerDD7 @
(DD@ A
nameDDA E
)DDE F
;DDF G
loggersEE 
[EE  
nameEE  $
]EE$ %
=EE& '
newEE( +
Log4NetLoggerEE, 9
(EE9 :
log4NetLoggerEE: G
)EEG H
;EEH I
}FF 
}GG 
}HH 
returnJJ 
loggersJJ 
[JJ 
nameJJ 
]JJ  
;JJ  !
}KK 	
}LL 
}MM Ú7
oD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Logging\Implementation\Log4NetLogger.cs
	namespace

 	
	SpecDrill


 
.

 
Infrastructure

 "
.

" #
Logging

# *
.

* +
Implementation

+ 9
{ 
class 	
Log4NetLogger
 
: 
ILogger !
{ 
private 
readonly 
ILog 
logger $
;$ %
public 
Log4NetLogger 
( 
ILog !
logger" (
)( )
{ 	
this 
. 
logger 
= 
logger  
;  !
} 	
public 
void 
Log 
( 
LogLevel  
level! &
,& '
object( .
message/ 6
)6 7
{ 	

CallLogger 
( 
level 
, 
message %
)% &
;& '
} 	
public 
void 
Log 
( 
LogLevel  
level! &
,& '
string( .
format/ 5
,5 6
params7 =
object> D
[D E
]E F
argsG K
)K L
{ 	

CallLogger 
( 
level 
, 
string $
.$ %
Format% +
(+ ,
format, 2
,2 3
args4 8
)8 9
)9 :
;: ;
} 	
public 
void 
Log 
( 
LogLevel  
level! &
,& '
	Exception( 1
	exception2 ;
,; <
object= C
messageD K
)K L
{   	

CallLogger!! 
(!! 
level!! 
,!! 
message!! %
,!!% &
	exception!!' 0
)!!0 1
;!!1 2
}"" 	
public$$ 
void$$ 
Log$$ 
($$ 
LogLevel$$  
level$$! &
,$$& '
	Exception$$( 1
	exception$$2 ;
,$$; <
string$$= C
format$$D J
,$$J K
params$$L R
object$$S Y
[$$Y Z
]$$Z [
args$$\ `
)$$` a
{%% 	

CallLogger&& 
(&& 
level&& 
,&& 
string&& $
.&&$ %
Format&&% +
(&&+ ,
format&&, 2
,&&2 3
args&&4 8
)&&8 9
,&&9 :
	exception&&; D
)&&D E
;&&E F
}'' 	
private)) 
void)) 

CallLogger)) 
())  
LogLevel))  (
level))) .
,)). /
object))0 6
message))7 >
,))> ?
	Exception))@ I
	exception))J S
=))T U
null))V Z
)))Z [
{** 	
switch++ 
(++ 
level++ 
)++ 
{,, 
case-- 
LogLevel-- 
.-- 
Debug-- #
:--# $
Trace.. 
... 
	WriteLine.. #
(..# $
$"..$ &
DEBUG - ..& .
{... /
message../ 6
}..6 7
, ..7 9
{..9 :
	exception..: C
?..C D
...D E
ToString..E M
(..M N
)..N O
??..P R
$str..S [
}..[ \
"..\ ]
)..] ^
;..^ _
if// 
(// 
logger// 
.// 
IsDebugEnabled// -
)//- .
{00 
logger11 
.11 
Debug11 $
(11$ %
message11% ,
,11, -
	exception11. 7
)117 8
;118 9
}22 
return33 
;33 
case44 
LogLevel44 
.44 
Error44 #
:44# $
Trace55 
.55 
	WriteLine55 #
(55# $
$"55$ &
ERROR - 55& .
{55. /
message55/ 6
}556 7
, 557 9
{559 :
	exception55: C
?55C D
.55D E
ToString55E M
(55M N
)55N O
??55P R
$str55S [
}55[ \
"55\ ]
)55] ^
;55^ _
if66 
(66 
logger66 
.66 
IsErrorEnabled66 -
)66- .
{77 
logger88 
.88 
Error88 $
(88$ %
message88% ,
,88, -
	exception88. 7
)887 8
;888 9
}99 
return:: 
;:: 
case;; 
LogLevel;; 
.;; 
Fatal;; #
:;;# $
Trace<< 
.<< 
	WriteLine<< #
(<<# $
$"<<$ &
FATAL - <<& .
{<<. /
message<</ 6
}<<6 7
, <<7 9
{<<9 :
	exception<<: C
?<<C D
.<<D E
ToString<<E M
(<<M N
)<<N O
??<<P R
$str<<S [
}<<[ \
"<<\ ]
)<<] ^
;<<^ _
if== 
(== 
logger== 
.== 
IsFatalEnabled== -
)==- .
{>> 
logger?? 
.?? 
Fatal?? $
(??$ %
message??% ,
,??, -
	exception??. 7
)??7 8
;??8 9
}@@ 
returnAA 
;AA 
caseBB 
LogLevelBB 
.BB 
InfoBB "
:BB" #
TraceCC 
.CC 
	WriteLineCC #
(CC# $
$"CC$ &
INFO - CC& -
{CC- .
messageCC. 5
}CC5 6
, CC6 8
{CC8 9
	exceptionCC9 B
?CCB C
.CCC D
ToStringCCD L
(CCL M
)CCM N
??CCO Q
$strCCR Z
}CCZ [
"CC[ \
)CC\ ]
;CC] ^
ifDD 
(DD 
loggerDD 
.DD 
IsInfoEnabledDD ,
)DD, -
{EE 
loggerFF 
.FF 
InfoFF #
(FF# $
messageFF$ +
,FF+ ,
	exceptionFF- 6
)FF6 7
;FF7 8
}GG 
returnHH 
;HH 
defaultII 
:II 
TraceJJ 
.JJ 
	WriteLineJJ #
(JJ# $
$"JJ$ &
WARN - JJ& -
{JJ- .
messageJJ. 5
}JJ5 6
, JJ6 8
{JJ8 9
	exceptionJJ9 B
?JJB C
.JJC D
ToStringJJD L
(JJL M
)JJM N
??JJO Q
$strJJR Z
}JJZ [
"JJ[ \
)JJ\ ]
;JJ] ^
ifKK 
(KK 
loggerKK 
.KK 
IsWarnEnabledKK ,
)KK, -
{LL 
loggerMM 
.MM 
WarnMM #
(MM# $
messageMM$ +
,MM+ ,
	exceptionMM- 6
)MM6 7
;MM7 8
}NN 
returnOO 
;OO 
}PP 
}QQ 	
}RR 
}SS à
lD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Logging\Interfaces\ILoggerFactory.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
." #
Logging# *
.* +

Interfaces+ 5
{ 
public 

	interface 
ILoggerFactory #
{ 
ILogger 
Get 
( 
string 
name 
)  
;  !
} 
} ç
VD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Logging\Log.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
." #
Logging# *
{ 
public		 

static		 
class		 
Log		 
{

 
private 
static 
readonly 
ILoggerFactory  .
loggerFactory/ <
;< =
static 
Log 
( 
) 
{ 	
loggerFactory 
= 
new 
Log4NetFactory  .
(. /
)/ 0
;0 1
} 	
public 
static 
ILogger 
Get !
(! "
string" (
name) -
)- .
{ 	
return 
	GetLogger 
( 
loggerFactory *
.* +
Get+ .
(. /
name/ 3
)3 4
)4 5
;5 6
} 	
public 
static 
ILogger 
Get !
<! "
T" #
># $
($ %
)% &
{ 	
return 
	GetLogger 
( 
loggerFactory *
.* +
Get+ .
(. /
typeof/ 5
(5 6
T6 7
)7 8
.8 9
	Namespace9 B
)B C
)C D
;D E
} 	
public 
static 
ILogger 
Get !
(! "
Type" &
type' +
)+ ,
{ 	
return 
	GetLogger 
( 
loggerFactory *
.* +
Get+ .
(. /
type/ 3
.3 4
	Namespace4 =
)= >
)> ?
;? @
} 	
private   
static   
ILogger   
	GetLogger   (
(  ( )
ILogger  ) 0
logger  1 7
)  7 8
{!! 	
if"" 
("" 
logger"" 
=="" 
null"" 
)"" 
Trace## 
.## 
Write## 
(## 
$"## 
Logger is null!## -
"##- .
)##. /
;##/ 0
return$$ 
logger$$ 
;$$ 
}%% 	
}'' 
}(( ©ò
cD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Logging\LoggerExtensions.cs
	namespace 	
	SpecDrill
 
. 
Infrastructure "
." #
Logging# *
{ 
public 

static 
class 
LoggerExtensions (
{ 
public		 
static		 
void		 
Info		 
(		  
this		  $
ILogger		% ,
logger		- 3
,		3 4
object		5 ;
message		< C
)		C D
{

 	
if 
( 
logger 
== 
null 
) 
Trace 
. 
Write 
( 
message #
)# $
;$ %
else 
logger 
. 
Log 
( 
LogLevel #
.# $
Info$ (
,( )
message* 1
)1 2
;2 3
} 	
public 
static 
void 
Info 
(  
this  $
ILogger% ,
logger- 3
,3 4
string5 ;
format< B
,B C
paramsD J
objectK Q
[Q R
]R S
argsT X
)X Y
{ 	
if 
( 
logger 
== 
null 
) 
Trace 
. 
Write 
( 
string "
." #
Format# )
() *
format* 0
,0 1
args2 6
)6 7
)7 8
;8 9
else 
logger 
. 
Log 
( 
LogLevel #
.# $
Info$ (
,( )
format* 0
,0 1
args2 6
)6 7
;7 8
} 	
public 
static 
void 
Info 
(  
this  $
ILogger% ,
logger- 3
,3 4
	Exception5 >
	exception? H
,H I
objectJ P
messageQ X
)X Y
{ 	
if 
( 
logger 
== 
null 
) 
Trace 
. 
Write 
( 
$" 
{ 
	exception (
.( )
Message) 0
}0 1
:1 2
{2 3
message3 :
}: ;
"; <
)< =
;= >
else 
logger 
. 
Log 
( 
LogLevel #
.# $
Info$ (
,( )
	exception* 3
,3 4
message5 <
)< =
;= >
} 	
public 
static 
void 
Info 
(  
this  $
ILogger% ,
logger- 3
,3 4
	Exception5 >
	exception? H
,H I
stringJ P
formatQ W
,W X
paramsY _
object` f
[f g
]g h
argsi m
)m n
{   	
if!! 
(!! 
logger!! 
==!! 
null!! 
)!! 
Trace"" 
."" 
Write"" 
("" 
$""" 
{"" 
	exception"" (
.""( )
Message"") 0
}""0 1
:""1 2
{""2 3
string""3 9
.""9 :
Format"": @
(""@ A
format""A G
,""G H
args""I M
)""M N
}""N O
"""O P
)""P Q
;""Q R
else## 
logger$$ 
.$$ 
Log$$ 
($$ 
LogLevel$$ #
.$$# $
Info$$$ (
,$$( )
	exception$$* 3
,$$3 4
format$$5 ;
,$$; <
args$$= A
)$$A B
;$$B C
}%% 	
public'' 
static'' 
void'' 
Warning'' "
(''" #
this''# '
ILogger''( /
logger''0 6
,''6 7
object''8 >
message''? F
)''F G
{(( 	
if)) 
()) 
logger)) 
==)) 
null)) 
))) 
Trace** 
.** 
Write** 
(** 
message** #
)**# $
;**$ %
else++ 
logger,, 
.,, 
Log,, 
(,, 
LogLevel,, #
.,,# $
Warning,,$ +
,,,+ ,
message,,- 4
),,4 5
;,,5 6
}-- 	
public.. 
static.. 
void.. 
Warning.. "
(.." #
this..# '
ILogger..( /
logger..0 6
,..6 7
string..8 >
format..? E
,..E F
params..G M
object..N T
[..T U
]..U V
args..W [
)..[ \
{// 	
if00 
(00 
logger00 
==00 
null00 
)00 
Trace11 
.11 
Write11 
(11 
string11 "
.11" #
Format11# )
(11) *
format11* 0
,110 1
args112 6
)116 7
)117 8
;118 9
else22 
logger33 
.33 
Log33 
(33 
LogLevel33 #
.33# $
Warning33$ +
,33+ ,
format33- 3
,333 4
args335 9
)339 :
;33: ;
}44 	
public55 
static55 
void55 
Warning55 "
(55" #
this55# '
ILogger55( /
logger550 6
,556 7
	Exception558 A
	exception55B K
,55K L
object55M S
message55T [
)55[ \
{66 	
if77 
(77 
logger77 
==77 
null77 
)77 
Trace88 
.88 
Write88 
(88 
$"88 
{88 
	exception88 (
.88( )
Message88) 0
}880 1
:881 2
{882 3
message883 :
}88: ;
"88; <
)88< =
;88= >
else99 
logger:: 
.:: 
Log:: 
(:: 
LogLevel:: #
.::# $
Warning::$ +
,::+ ,
	exception::- 6
,::6 7
message::8 ?
)::? @
;::@ A
};; 	
public<< 
static<< 
void<< 
Warning<< "
(<<" #
this<<# '
ILogger<<( /
logger<<0 6
,<<6 7
	Exception<<8 A
	exception<<B K
,<<K L
string<<M S
format<<T Z
,<<Z [
params<<\ b
object<<c i
[<<i j
]<<j k
args<<l p
)<<p q
{== 	
if>> 
(>> 
logger>> 
==>> 
null>> 
)>> 
Trace?? 
.?? 
Write?? 
(?? 
$"?? 
{?? 
	exception?? (
.??( )
Message??) 0
}??0 1
:??1 2
{??2 3
string??3 9
.??9 :
Format??: @
(??@ A
format??A G
,??G H
args??I M
)??M N
}??N O
"??O P
)??P Q
;??Q R
else@@ 
loggerAA 
.AA 
LogAA 
(AA 
LogLevelAA #
.AA# $
WarningAA$ +
,AA+ ,
	exceptionAA- 6
,AA6 7
formatAA8 >
,AA> ?
argsAA@ D
)AAD E
;AAE F
}BB 	
publicDD 
staticDD 
voidDD 
DebugDD  
(DD  !
thisDD! %
ILoggerDD& -
loggerDD. 4
,DD4 5
objectDD6 <
messageDD= D
)DDD E
{EE 	
ifFF 
(FF 
loggerFF 
==FF 
nullFF 
)FF 
TraceGG 
.GG 
WriteGG 
(GG 
messageGG #
)GG# $
;GG$ %
elseHH 
loggerII 
.II 
LogII 
(II 
LogLevelII #
.II# $
DebugII$ )
,II) *
messageII+ 2
)II2 3
;II3 4
}JJ 	
publicKK 
staticKK 
voidKK 
DebugKK  
(KK  !
thisKK! %
ILoggerKK& -
loggerKK. 4
,KK4 5
stringKK6 <
formatKK= C
,KKC D
paramsKKE K
objectKKL R
[KKR S
]KKS T
argsKKU Y
)KKY Z
{LL 	
ifMM 
(MM 
loggerMM 
==MM 
nullMM 
)MM 
TraceNN 
.NN 
WriteNN 
(NN 
stringNN "
.NN" #
FormatNN# )
(NN) *
formatNN* 0
,NN0 1
argsNN2 6
)NN6 7
)NN7 8
;NN8 9
elseOO 
loggerPP 
.PP 
LogPP 
(PP 
LogLevelPP #
.PP# $
DebugPP$ )
,PP) *
formatPP+ 1
,PP1 2
argsPP3 7
)PP7 8
;PP8 9
}QQ 	
publicRR 
staticRR 
voidRR 
DebugRR  
(RR  !
thisRR! %
ILoggerRR& -
loggerRR. 4
,RR4 5
	ExceptionRR6 ?
	exceptionRR@ I
,RRI J
objectRRK Q
messageRRR Y
)RRY Z
{SS 	
ifTT 
(TT 
loggerTT 
==TT 
nullTT 
)TT 
TraceUU 
.UU 
WriteUU 
(UU 
$"UU 
{UU 
	exceptionUU (
.UU( )
MessageUU) 0
}UU0 1
:UU1 2
{UU2 3
messageUU3 :
}UU: ;
"UU; <
)UU< =
;UU= >
elseVV 
loggerWW 
.WW 
LogWW 
(WW 
LogLevelWW #
.WW# $
DebugWW$ )
,WW) *
	exceptionWW+ 4
,WW4 5
messageWW6 =
)WW= >
;WW> ?
}XX 	
publicYY 
staticYY 
voidYY 
DebugYY  
(YY  !
thisYY! %
ILoggerYY& -
loggerYY. 4
,YY4 5
	ExceptionYY6 ?
	exceptionYY@ I
,YYI J
stringYYK Q
formatYYR X
,YYX Y
paramsYYZ `
objectYYa g
[YYg h
]YYh i
argsYYj n
)YYn o
{ZZ 	
if[[ 
([[ 
logger[[ 
==[[ 
null[[ 
)[[ 
Trace\\ 
.\\ 
Write\\ 
(\\ 
$"\\ 
{\\ 
	exception\\ (
.\\( )
Message\\) 0
}\\0 1
:\\1 2
{\\2 3
string\\3 9
.\\9 :
Format\\: @
(\\@ A
format\\A G
,\\G H
args\\I M
)\\M N
}\\N O
"\\O P
)\\P Q
;\\Q R
else]] 
logger^^ 
.^^ 
Log^^ 
(^^ 
LogLevel^^ #
.^^# $
Debug^^$ )
,^^) *
	exception^^+ 4
,^^4 5
format^^6 <
,^^< =
args^^> B
)^^B C
;^^C D
}__ 	
publicaa 
staticaa 
voidaa 
Erroraa  
(aa  !
thisaa! %
ILoggeraa& -
loggeraa. 4
,aa4 5
objectaa6 <
messageaa= D
)aaD E
{bb 	
ifcc 
(cc 
loggercc 
==cc 
nullcc 
)cc 
Tracedd 
.dd 
Writedd 
(dd 
messagedd #
)dd# $
;dd$ %
elseee 
loggerff 
.ff 
Logff 
(ff 
LogLevelff #
.ff# $
Errorff$ )
,ff) *
messageff+ 2
)ff2 3
;ff3 4
}gg 	
publichh 
statichh 
voidhh 
Errorhh  
(hh  !
thishh! %
ILoggerhh& -
loggerhh. 4
,hh4 5
stringhh6 <
formathh= C
,hhC D
paramshhE K
objecthhL R
[hhR S
]hhS T
argshhU Y
)hhY Z
{ii 	
ifjj 
(jj 
loggerjj 
==jj 
nulljj 
)jj 
Tracekk 
.kk 
Writekk 
(kk 
stringkk "
.kk" #
Formatkk# )
(kk) *
formatkk* 0
,kk0 1
argskk2 6
)kk6 7
)kk7 8
;kk8 9
elsell 
loggermm 
.mm 
Logmm 
(mm 
LogLevelmm #
.mm# $
Errormm$ )
,mm) *
formatmm+ 1
,mm1 2
argsmm3 7
)mm7 8
;mm8 9
}nn 	
publicoo 
staticoo 
voidoo 
Erroroo  
(oo  !
thisoo! %
ILoggeroo& -
loggeroo. 4
,oo4 5
	Exceptionoo6 ?
	exceptionoo@ I
,ooI J
objectooK Q
messageooR Y
)ooY Z
{pp 	
ifqq 
(qq 
loggerqq 
==qq 
nullqq 
)qq 
Tracerr 
.rr 
Writerr 
(rr 
$"rr 
{rr 
	exceptionrr (
.rr( )
Messagerr) 0
}rr0 1
:rr1 2
{rr2 3
messagerr3 :
}rr: ;
"rr; <
)rr< =
;rr= >
elsess 
loggertt 
.tt 
Logtt 
(tt 
LogLeveltt #
.tt# $
Errortt$ )
,tt) *
	exceptiontt+ 4
,tt4 5
messagett6 =
)tt= >
;tt> ?
}uu 	
publicvv 
staticvv 
voidvv 
Errorvv  
(vv  !
thisvv! %
ILoggervv& -
loggervv. 4
,vv4 5
	Exceptionvv6 ?
	exceptionvv@ I
,vvI J
stringvvK Q
formatvvR X
,vvX Y
paramsvvZ `
objectvva g
[vvg h
]vvh i
argsvvj n
)vvn o
{ww 	
ifxx 
(xx 
loggerxx 
==xx 
nullxx 
)xx 
Traceyy 
.yy 
Writeyy 
(yy 
$"yy 
{yy 
	exceptionyy (
.yy( )
Messageyy) 0
}yy0 1
:yy1 2
{yy2 3
stringyy3 9
.yy9 :
Formatyy: @
(yy@ A
formatyyA G
,yyG H
argsyyI M
)yyM N
}yyN O
"yyO P
)yyP Q
;yyQ R
elsezz 
logger{{ 
.{{ 
Log{{ 
({{ 
LogLevel{{ #
.{{# $
Error{{$ )
,{{) *
	exception{{+ 4
,{{4 5
format{{6 <
,{{< =
args{{> B
){{B C
;{{C D
}|| 	
public~~ 
static~~ 
void~~ 
Fatal~~  
(~~  !
this~~! %
ILogger~~& -
logger~~. 4
,~~4 5
object~~6 <
message~~= D
)~~D E
{ 	
if
ÄÄ 
(
ÄÄ 
logger
ÄÄ 
==
ÄÄ 
null
ÄÄ 
)
ÄÄ 
Trace
ÅÅ 
.
ÅÅ 
Write
ÅÅ 
(
ÅÅ 
message
ÅÅ #
)
ÅÅ# $
;
ÅÅ$ %
else
ÇÇ 
logger
ÉÉ 
.
ÉÉ 
Log
ÉÉ 
(
ÉÉ 
LogLevel
ÉÉ #
.
ÉÉ# $
Fatal
ÉÉ$ )
,
ÉÉ) *
message
ÉÉ+ 2
)
ÉÉ2 3
;
ÉÉ3 4
}
ÑÑ 	
public
ÖÖ 
static
ÖÖ 
void
ÖÖ 
Fatal
ÖÖ  
(
ÖÖ  !
this
ÖÖ! %
ILogger
ÖÖ& -
logger
ÖÖ. 4
,
ÖÖ4 5
string
ÖÖ6 <
format
ÖÖ= C
,
ÖÖC D
params
ÖÖE K
object
ÖÖL R
[
ÖÖR S
]
ÖÖS T
args
ÖÖU Y
)
ÖÖY Z
{
ÜÜ 	
if
áá 
(
áá 
logger
áá 
==
áá 
null
áá 
)
áá 
Trace
àà 
.
àà 
Write
àà 
(
àà 
string
àà "
.
àà" #
Format
àà# )
(
àà) *
format
àà* 0
,
àà0 1
args
àà2 6
)
àà6 7
)
àà7 8
;
àà8 9
else
ââ 
logger
ää 
.
ää 
Log
ää 
(
ää 
LogLevel
ää #
.
ää# $
Fatal
ää$ )
,
ää) *
format
ää+ 1
,
ää1 2
args
ää3 7
)
ää7 8
;
ää8 9
}
ãã 	
public
åå 
static
åå 
void
åå 
Fatal
åå  
(
åå  !
this
åå! %
ILogger
åå& -
logger
åå. 4
,
åå4 5
	Exception
åå6 ?
	exception
åå@ I
,
ååI J
object
ååK Q
message
ååR Y
)
ååY Z
{
çç 	
if
éé 
(
éé 
logger
éé 
==
éé 
null
éé 
)
éé 
Trace
èè 
.
èè 
Write
èè 
(
èè 
$"
èè 
{
èè 
	exception
èè (
.
èè( )
Message
èè) 0
}
èè0 1
:
èè1 2
{
èè2 3
message
èè3 :
}
èè: ;
"
èè; <
)
èè< =
;
èè= >
else
êê 
logger
ëë 
.
ëë 
Log
ëë 
(
ëë 
LogLevel
ëë #
.
ëë# $
Fatal
ëë$ )
,
ëë) *
	exception
ëë+ 4
,
ëë4 5
message
ëë6 =
)
ëë= >
;
ëë> ?
}
íí 	
public
ìì 
static
ìì 
void
ìì 
Fatal
ìì  
(
ìì  !
this
ìì! %
ILogger
ìì& -
logger
ìì. 4
,
ìì4 5
	Exception
ìì6 ?
	exception
ìì@ I
,
ììI J
string
ììK Q
format
ììR X
,
ììX Y
params
ììZ `
object
ììa g
[
ììg h
]
ììh i
args
ììj n
)
ììn o
{
îî 	
if
ïï 
(
ïï 
logger
ïï 
==
ïï 
null
ïï 
)
ïï 
Trace
ññ 
.
ññ 
Write
ññ 
(
ññ 
$"
ññ 
{
ññ 
	exception
ññ (
.
ññ( )
Message
ññ) 0
}
ññ0 1
:
ññ1 2
{
ññ2 3
string
ññ3 9
.
ññ9 :
Format
ññ: @
(
ññ@ A
format
ññA G
,
ññG H
args
ññI M
)
ññM N
}
ññN O
"
ññO P
)
ññP Q
;
ññQ R
else
óó 
logger
òò 
.
òò 
Log
òò 
(
òò 
LogLevel
òò #
.
òò# $
Fatal
òò$ )
,
òò) *
	exception
òò+ 4
,
òò4 5
format
òò6 <
,
òò< =
args
òò> B
)
òòB C
;
òòC D
}
ôô 	
}
öö 
}õõ ç
bD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str 3
)3 4
]4 5
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str )
)) *
]* +
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str 5
)5 6
]6 7
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *ç[
OD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Infrastructure\Wait.cs
	namespace 	
	SpecDrill
 
{ 
public 

class 
RetryWaitContext !
{ 
	protected 
ILogger 
Log 
= 
Infrastructure  .
.. /
Logging/ 6
.6 7
Log7 :
.: ;
Get; >
<> ?
RetryWaitContext? O
>O P
(P Q
)Q R
;R S
public 
int 

RetryCount 
{ 
get  #
;# $
set% (
;( )
}* +
public 
TimeSpan 
? 
RetryInterval &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
private 
Action 
action 
= 
(  !
)! "
=># %
{& '
return( .
;. /
}0 1
;1 2
public 
void 
Until 
( 
Func 
< 
bool #
># $
waitCondition% 2
)2 3
{ 	
	Stopwatch 
sw 
= 
new 
	Stopwatch (
(( )
)) *
;* +
var 
retryInterval 
= 
this  $
.$ %
RetryInterval% 2
??3 5
TimeSpan6 >
.> ?
FromSeconds? J
(J K
$numK M
)M N
;N O
int 

retryCount 
= 
this !
.! "

RetryCount" ,
;, -
while 
( 

retryCount 
>=  
$num! "
)" #
{   
bool!! 
actionSucceeded!! $
=!!% &
false!!' ,
;!!, -
try## 
{$$ 
action%% 
(%% 
)%% 
;%% 
actionSucceeded&& #
=&&$ %
true&&& *
;&&* +
}'' 
catch(( 
((( 
	Exception((  
e((! "
)((" #
{)) 
Log** 
.** 
Error** 
(** 
e** 
,**  
$"**! #%
TryingAction: retryCount=**# <
{**< =

retryCount**= G
}**G H
"**H I
)**I J
;**J K
}++ 

retryCount-- 
---- 
;-- 
if.. 
(.. 
actionSucceeded.. #
)..# $
{// 
sw00 
.00 
Start00 
(00 
)00 
;00 
while11 
(11 
sw11 
.11 
Elapsed11 %
<11& '
retryInterval11( 5
)115 6
{22 
try33 
{44 
if55 
(55  
waitCondition55  -
(55- .
)55. /
)55/ 0
return66  &
;66& '
}77 
catch88 
(88 
	Exception88 (
e88) *
)88* +
{99 
Log:: 
.::  
Error::  %
(::% &
e::& '
,::' (
$str::) k
,::k l

retryCount::m w
,::w x
this::y }
.::} ~
RetryInterval	::~ ã
??
::å é
TimeSpan
::è ó
.
::ó ò
FromSeconds
::ò £
(
::£ §
$num
::§ •
)
::• ¶
,
::¶ ß
retryInterval
::® µ
)
::µ ∂
;
::∂ ∑
};; 
Thread== 
.== 
Sleep== $
(==$ %
$num==% '
)==' (
;==( )
}>> 
sw?? 
.?? 
Reset?? 
(?? 
)?? 
;?? 
}@@ 
}AA 
swBB 
.BB 
StopBB 
(BB 
)BB 
;BB 
throwDD 
newDD 
TimeoutExceptionDD &
(DD& '
stringDD' -
.DD- .
FormatDD. 4
(DD4 5
$strDD5 i
,DDi j
thisDDk o
.DDo p

RetryCountDDp z
,DDz {
retryInterval	DD| â
)
DDâ ä
)
DDä ã
;
DDã å
}EE 	
publicGG 
RetryWaitContextGG 
DoingGG  %
(GG% &
ActionGG& ,
actionGG- 3
)GG3 4
{HH 	
thisII 
.II 
actionII 
=II 
actionII  
??II! #
thisII$ (
.II( )
actionII) /
;II/ 0
returnJJ 
thisJJ 
;JJ 
}KK 	
}LL 
publicNN 

classNN 
MaxWaitContextNN 
{OO 
	protectedPP 
staticPP 
readonlyPP !
ILoggerPP" )
LogPP* -
=PP. /
InfrastructurePP0 >
.PP> ?
LoggingPP? F
.PPF G
LogPPG J
.PPJ K
GetPPK N
<PPN O
MaxWaitContextPPO ]
>PP] ^
(PP^ _
)PP_ `
;PP` a
publicQQ 
TimeSpanQQ 
MaximumWaitQQ #
{QQ$ %
getQQ& )
;QQ) *
setQQ+ .
;QQ. /
}QQ0 1
privateRR 
FuncRR 
<RR 
FuncRR 
<RR 
boolRR 
>RR 
,RR  
boolRR! %
,RR% &
TupleRR' ,
<RR, -
boolRR- 1
,RR1 2
	ExceptionRR2 ;
>RR; <
>RR< =
safeWaitRR> F
=RRG H
(RRI J
waitConditionRRJ W
,RRW X
throwExceptionRRY g
)RRg h
=>RRi k
{SS 	
boolYY 
resultYY 
=YY 
falseYY 
;YY  
	ExceptionZZ 
	exceptionZZ 
=ZZ  !
nullZZ" &
;ZZ& '
try[[ 
{\\ 
result]] 
=]] 
waitCondition]] &
(]]& '
)]]' (
;]]( )
}^^ 
catch__ 
(__ 
	Exception__ 
e__ 
)__ 
{`` 
Logaa 
.aa 
Erroraa 
(aa 
eaa 
,aa 
$straa ,
)aa, -
;aa- .
	exceptionbb 
=bb 
ebb 
;bb 
ifcc 
(cc 
throwExceptioncc "
)cc" #
throwdd 
;dd 
}ee 
returnff 
Tupleff 
.ff 
Createff 
(ff  
resultff  &
,ff& '
	exceptionff( 1
)ff1 2
;ff2 3
}gg 	
;gg	 

publicii 
voidii 
Untilii 
(ii 
Funcii 
<ii 
boolii #
>ii# $
waitConditionii% 2
,ii2 3
boolii4 8
throwExceptionii9 G
=iiH I
trueiiJ N
)iiN O
{jj 	
Funckk 
<kk 
Tuplekk 
<kk 
boolkk 
,kk 
	Exceptionkk &
>kk& '
>kk' (
safeWaitConditionkk) :
=kk; <
(kk= >
)kk> ?
=>kk@ B
safeWaitkkC K
(kkK L
waitConditionkkL Y
,kkY Z
falsekk[ `
)kk` a
;kka b
boolll 

conclusivell 
=ll 
falsell #
;ll# $
	Exceptionmm 
	lastErrormm 
=mm  !
nullmm" &
;mm& '
	Stopwatchnn 
swnn 
=nn 
newnn 
	Stopwatchnn (
(nn( )
)nn) *
;nn* +
swoo 
.oo 
Startoo 
(oo 
)oo 
;oo 
whilepp 
(pp 
swpp 
.pp 
Elapsedpp 
<pp 
MaximumWaitpp  +
&&pp, .
!pp/ 0

conclusivepp0 :
)pp: ;
{qq 
varrr 

waitResultrr 
=rr  
safeWaitConditionrr! 2
(rr2 3
)rr3 4
;rr4 5
	lastErrortt 
=tt 

waitResulttt &
.tt& '
Item2tt' ,
;tt, -
ifuu 
(uu 
	lastErroruu 
!=uu  
nulluu! %
)uu% &

conclusivevv 
=vv  
falsevv! &
;vv& '
elseww 

conclusivexx 
=xx  

waitResultxx! +
.xx+ ,
Item1xx, 1
;xx1 2
ifzz 
(zz 

conclusivezz 
)zz 
{{{ 
return|| 
;|| 
}}} 
Thread 
. 
Sleep 
( 
$num 
)  
;  !
}
ÄÄ 
sw
ÅÅ 
.
ÅÅ 
Stop
ÅÅ 
(
ÅÅ 
)
ÅÅ 
;
ÅÅ 
if
ÉÉ 
(
ÉÉ 
throwException
ÉÉ 
)
ÉÉ 
{
ÑÑ 
throw
ÖÖ 
new
ÖÖ 
TimeoutException
ÖÖ *
(
ÖÖ* +
$"
ÖÖ+ -
Explicit Wait of 
ÖÖ- >
{
ÖÖ> ?
this
ÖÖ? C
.
ÖÖC D
MaximumWait
ÖÖD O
}
ÖÖO P#
 Timed Out ! Reason: 
ÖÖP e
{
ÖÖe f
	lastError
ÖÖf o
?
ÖÖo p
.
ÖÖp q
ToString
ÖÖq y
(
ÖÖy z
)
ÖÖz {
??
ÖÖ| ~
$strÖÖ ã
}ÖÖã å
"ÖÖå ç
)ÖÖç é
;ÖÖé è
}
ÜÜ 
}
áá 	
}
àà 
public
ää 

static
ää 
class
ää 
Wait
ää 
{
ãã 
public
åå 
static
åå 
MaxWaitContext
åå $

NoMoreThan
åå% /
(
åå/ 0
TimeSpan
åå0 8
maximumWait
åå9 D
)
ååD E
{
çç 	
return
éé 
new
éé 
MaxWaitContext
éé %
{
éé& '
MaximumWait
éé( 3
=
éé4 5
maximumWait
éé6 A
}
ééB C
;
ééC D
}
èè 	
public
óó 
static
óó 
RetryWaitContext
óó &
	WithRetry
óó' 0
(
óó0 1
int
óó1 4

retryCount
óó5 ?
=
óó@ A
$num
óóB C
,
óóC D
TimeSpan
óóE M
?
óóM N
retryInterval
óóO \
=
óó] ^
null
óó_ c
)
óóc d
{
òò 	
return
ôô 
new
ôô 
RetryWaitContext
ôô '
{
ôô( )

RetryCount
ôô* 4
=
ôô5 6

retryCount
ôô7 A
,
ôôA B
RetryInterval
ôôC P
=
ôôQ R
retryInterval
ôôS `
}
ôôa b
;
ôôb c
}
öö 	
public
úú 
static
úú 
void
úú 
Until
úú  
(
úú  !
Func
úú! %
<
úú% &
bool
úú& *
>
úú* +
waitCondition
úú, 9
)
úú9 :
{
ùù 	
new
ûû 
MaxWaitContext
ûû 
{
üü 
MaximumWait
†† 
=
†† 
TimeSpan
†† &
.
††& '
FromMilliseconds
††' 7
(
††7 8
Globals
††8 ?
.
††? @
Configuration
††@ M
.
††M N
MaxWait
††N U
)
††U V
}
°° 
.
°° 
Until
°° 
(
°° 
waitCondition
°° !
)
°°! "
;
°°" #
}
¢¢ 	
}
££ 
}§§ 