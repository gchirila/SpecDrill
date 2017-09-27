’$
OD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\Core\IBrowser.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
.6 7
Core7 ;
{ 
public 

	interface 
IBrowser 
{ 
T		 	
Open		
 
<		 
T		 
>		 
(		 
)		 
where

 
T

 
:

 
IPage

 
;

 
T 	

CreatePage
 
< 
T 
> 
( 
) 
where 
T 
: 
IPage 
; 
T 	
CreateControl
 
< 
T 
> 
( 
T 
fromInstance )
)) *
where 
T 
: 
IElement 
; 
void 
GoToUrl 
( 
string 
url 
)  
;  !
string 
	PageTitle 
{ 
get 
; 
}  !
IDisposable 
ImplicitTimeout #
(# $
TimeSpan$ ,
implicitTimeout- <
,< =
string> D
messageE L
=M N
nullO S
)S T
;T U
void"" 
SwitchToFrame"" 
<"" 
T"" 
>"" 
("" 
IFrameElement"" +
<""+ ,
T"", -
>""- . 
seleniumFrameElement""/ C
)""C D
where""E J
T""K L
:""M N
class""O T
,""T U
IPage""V [
;""[ \
void$$ 
SwitchToWindow$$ 
<$$ 
T$$ 
>$$ 
($$ 
IWindowElement$$ -
<$$- .
T$$. /
>$$/ 0!
seleniumWindowElement$$1 F
)$$F G
where$$H M
T$$N O
:$$P Q
class$$R W
,$$W X
IPage$$Y ^
;$$^ _
SearchResult++ 
PeekElement++  
(++  !
IElement++! )
locator++* 1
)++1 2
;++2 3
void-- 
Exit-- 
(-- 
)-- 
;-- 
SearchResult33 
FindNativeElement33 &
(33& '
IElementLocator33' 6
locator337 >
)33> ?
;33? @
object55 
ExecuteJavascript55  
(55  !
string55! '
script55( .
,55. /
params550 6
object557 =
[55= >
]55> ?
	arguments55@ I
)55I J
;55J K
void77 
Hover77 
(77 
IElement77 
element77 #
)77# $
;77$ %
[99 	
Obsolete99	 
(99 
$str99 
)	99 Ä
]
99Ä Å
void:: 
DragAndDropElement:: 
(::  
IElement::  (
startFromElement::) 9
,::9 :
IElement::; C
stopToElement::D Q
)::Q R
;::R S
void;; 
DragAndDrop;; 
(;; 
IElement;; !
startFromElement;;" 2
,;;2 3
IElement;;4 <
stopToElement;;= J
);;J K
;;;K L
void== 
DragAndDrop== 
(== 
IElement== !
startFromElement==" 2
,==2 3
int==4 7
offsetX==8 ?
,==? @
int==A D
offsetY==E L
)==L M
;==M N
bool?? 
IsJQueryDefined?? 
{?? 
get?? "
;??" #
}??$ %
voidCC 
MaximizePageCC 
(CC 
)CC 
;CC 
voidEE 
RefreshPageEE 
(EE 
)EE 
;EE 
voidGG 
ClickGG 
(GG 
IElementGG 
elementGG #
)GG# $
;GG$ %
voidHH 
DoubleClickHH 
(HH 
IElementHH !
elementHH" )
)HH) *
;HH* +
IBrowserAlertJJ 
AlertJJ 
{JJ 
getJJ !
;JJ! "
}JJ# $
boolLL 
IsAlertPresentLL 
{LL 
getLL !
;LL! "
}LL# $
voidNN 
SwitchToDocumentNN 
(NN 
)NN 
;NN  
voidOO 
CloseLastWindowOO 
(OO 
)OO 
;OO 
stringPP 

GetPdfTextPP 
(PP 
)PP 
;PP 
}QQ 
}RR ‹
OD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IBrowserAlert.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public		 

	interface		 
IBrowserAlert		 "
{

 
void 
Accept 
( 
) 
; 
void 
Dismiss 
( 
) 
; 
string 
Text 
{ 
get 
; 
} 
void 
SendKeys 
( 
string 
keys !
)! "
;" #
} 
} ˆ
WD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IBrowserDriverFactory.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface !
IBrowserDriverFactory *
{ 
IBrowserDriver 
Create 
( 
BrowserNames *
browserName+ 6
)6 7
;7 8
} 
}		 ‚
PD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IBrowserDriver.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
IBrowserDriver #
{ 
void 
GoToUrl 
( 
string 
url 
)  
;  !
void 
Exit 
( 
) 
; 
string 
Title 
{ 
get 
; 
} 
void &
ChangeBrowserDriverTimeout '
(' (
System( .
.. /
TimeSpan/ 7
timeout8 ?
)? @
;@ A
ReadOnlyCollection"" 
<"" 
object"" !
>""! "
FindElements""# /
(""/ 0
IElementLocator""0 ?
locator""@ G
)""G H
;""H I
object++ 
ExecuteJavaScript++  
(++  !
string++! '
js++( *
,++* +
params++, 2
object++3 9
[++9 :
]++: ;
elements++< D
)++D E
;++E F
void-- 
MoveToElement-- 
(-- 
IElement-- #
locator--$ +
)--+ ,
;--, -
void// 
DragAndDrop// 
(// 
IElement// !
startFromElement//" 2
,//2 3
IElement//4 <
stopToElement//= J
)//J K
;//K L
void11 
DragAndDrop11 
(11 
IElement11 !
startFromElement11" 2
,112 3
int114 7
offsetX118 ?
,11? @
int11A D
offsetY11E L
)11L M
;11M N
void33 
RefreshPage33 
(33 
)33 
;33 
void55 
MaximizePage55 
(55 
)55 
;55 
void77 
Click77 
(77 
IElement77 
element77 #
)77# $
;77$ %
void99 
DoubleClick99 
(99 
IElement99 !
element99" )
)99) *
;99* +
IBrowserAlert;; 
Alert;; 
{;; 
get;; !
;;;! "
};;# $
bool== 
IsAlertPresent== 
{== 
get== !
;==! "
}==# $
void?? 
SwitchToDocument?? 
(?? 
)?? 
;??  
voidAA 
SwitchToFrameAA 
(AA 
IElementAA # 
seleniumFrameElementAA$ 8
)AA8 9
;AA9 :
voidCC 
SetWindowSizeCC 
(CC 
intCC 
initialWidthCC +
,CC+ ,
intCC- 0
initialHeightCC1 >
)CC> ?
;CC? @
voidEE 
SwitchToWindowEE 
<EE 
TEE 
>EE 
(EE 
IWindowElementEE -
<EE- .
TEE. /
>EE/ 0!
seleniumWindowElementEE1 F
)EEF G
whereEEH M
TEEN O
:EEO P
IPageEEP U
;EEU V
voidFF 
CloseLastWindowFF 
(FF 
)FF 
;FF 
stringGG 

GetPdfTextGG 
(GG 
)GG 
;GG 
}HH 
}II ù
PD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\ICustomElement.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
[		 
Obsolete		 
]		 
	interface

 
ICustomElement

 
:

 
IElement

 '
{ 
} 
} º
JD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IElement.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
IElement 
{ 
SearchResult %
NativeElementSearchResult .
{/ 0
get1 4
;4 5
}6 7
int 
Count 
{ 
get 
; 
} 
bool 

IsReadOnly 
{ 
get 
; 
}  
bool 
IsAvailable 
{ 
get 
; 
}  !
bool 
	IsEnabled 
{ 
get 
; 
} 
bool 
IsDisplayed 
{ 
get 
; 
}  !
IBrowser!! 
Browser!! 
{!! 
get!! 
;!! 
}!!  !
void## 
Click## 
(## 
bool## 
waitForSilence## &
=##' (
false##) .
)##. /
;##/ 0
void$$ 
DoubleClick$$ 
($$ 
bool$$ 
waitForSilence$$ ,
=$$- .
false$$/ 4
)$$4 5
;$$5 6
IElement++ 
SendKeys++ 
(++ 
string++  
keys++! %
,++% &
bool++' +
waitForSilence++, :
=++; <
false++= B
)++B C
;++C D
void11 
Blur11 
(11 
bool11 
waitForSilence11 %
=11& '
false11( -
)11- .
;11. /
IElement77 
Clear77 
(77 
bool77 
waitForSilence77 *
=77+ ,
false77- 2
)772 3
;773 4
string99 
Text99 
{99 
get99 
;99 
}99 
string@@ 
GetAttribute@@ 
(@@ 
string@@ "
attributeName@@# 0
)@@0 1
;@@1 2
stringBB 
GetCssValueBB 
(BB 
stringBB !
cssValueNameBB" .
)BB. /
;BB/ 0
voidDD 
HoverDD 
(DD 
boolDD 
waitForSilenceDD &
=DD' (
falseDD) .
)DD. /
;DD/ 0
voidFF 
DragAndDropToFF 
(FF 
IElementFF #
targetFF$ *
)FF* +
;FF+ ,
voidHH 
DragAndDropAtHH 
(HH 
intHH 
offsetXHH &
,HH& '
intHH( +
offsetYHH, 3
)HH3 4
;HH4 5
IElementJJ 
ParentJJ 
{JJ 
getJJ 
;JJ 
}JJ  
IElementLocatorLL 
LocatorLL 
{LL  !
getLL" %
;LL% &
}LL' (
IPageNN 
ContainingPageNN 
{NN 
getNN "
;NN" #
}NN$ %
}OO 
}PP Ì	
QD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IElementLocator.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

enum 
By 
{ 
Id 

,
 
	ClassName 
, 
CssSelector 
, 
XPath 
, 
Name		 
,		 
TagName

 
,

 
LinkText 
, 
PartialLinkText 
} 
public 

	interface 
IElementLocator $
{ 
By 

LocatorType 
{ 
get 
; 
} 
string 
LocatorValue 
{ 
get !
;! "
}# $
int 
? 
Index 
{ 
get 
; 
} 
IElementLocator 
Copy 
( 
) 
; 
IElementLocator 
CopyWithIndex %
(% &
int& )
index* /
)/ 0
;0 1
} 
} µ
XD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\Model\PageContextTypes.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
.6 7
Model7 <
{ 
public 

enum 
PageContextTypes  
{ 
Frame 
, 
Window 
} 
} Ã
OD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\WindowElement.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
IWindowElement #
<# $
out$ '
T( )
>) *
:+ ,
IElement- 5
where 
T 
: 
IPage 
{ 
T 	
Open
 
( 
) 
; 
}		 
}

 Å
OD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IFrameElement.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
IFrameElement "
<" #
out# &
T' (
>( )
:* +
IElement, 4
where 
T 
: 
IPage 
{ 
T 	
Open
 
( 
) 
; 
[

 	
Obsolete

	 
(

 
$str

 D
)

D E
]

E F
T 	
SwitchTo
 
( 
) 
; 
} 
} ´
TD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\INavigationElement.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
INavigationElement '
<' (
out( +
T, -
>- .
:/ 0
IElement1 9
where 
T 
: 
IPage 
{ 
T 	
Click
 
( 
) 
; 
T 	
DoubleClick
 
( 
) 
; 
} 
}		 ◊
JD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IControl.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
IControl 
: 
IElement  (
{ 
bool 
IsLoaded 
{ 
get 
; 
} 
} 
} Ü

PD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\ISelectElement.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
ISelectElement #
:$ %
IElement& .
{ 
ISelectElement 
SelectByText #
(# $
string$ *

optionText+ 5
)5 6
;6 7
ISelectElement 
SelectByValue $
($ %
string% +
optionValue, 7
)7 8
;8 9
ISelectElement 
SelectByIndex $
($ %
int% (
optionIndex) 4
)4 5
;5 6
string  
GetOptionTextByIndex #
(# $
int$ '
optionIndex( 3
)3 4
;4 5
string		 
SelectedOptionText		 !
{		" #
get		$ '
;		' (
}		) *
string

 
SelectedOptionValue

 "
{

# $
get

% (
;

( )
}

* +
int 
OptionsCount 
{ 
get 
; 
}  !
} 
} ¶
GD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\IPage.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
{ 
public 

	interface 
IPage 
: 
IElement %
,% &
IDisposable' 2
{ 
string		 
Title		 
{		 
get		 
;		 
}		 
bool

 
IsLoaded

 
{

 
get

 
;

 
}

 
PageContextTypes 
ContextType $
{% &
get' *
;* +
set, /
;/ 0
}1 2
void 
WaitForSilence 
( 
) 
; 
void 
RefreshPage 
( 
) 
; 
} 
} •
TD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\Model\SearchResult.cs
	namespace 	
	SpecDrill
 
. 
SecondaryPorts "
." #
AutomationFramework# 6
.6 7
Model7 <
{ 
public		 

class		 
SearchResult		 
{

 
private 
SearchResult 
( 
object #
nativeElement$ 1
,1 2
int3 6
count7 <
)< =
{> ?
this@ D
.D E
NativeElementE R
=S T
nativeElementU b
;b c
thisd h
.h i
Counti n
=o p
countq v
;v w
}x y
public 
object 
NativeElement #
{$ %
get& )
;) *
}+ ,
public 
int 
Count 
{ 
get 
; 
}  !
public 
static 
SearchResult "
Create# )
() *
object* 0
nativeElement1 >
,> ?
int@ C
countD I
)I J
{ 	
return 
new 
SearchResult #
(# $
nativeElement$ 1
,1 2
count3 8
)8 9
;9 :
} 	
public 
static 
SearchResult "
Empty# (
=>) +
Create, 2
(2 3
null3 7
,7 8
$num9 :
): ;
;; <
public 
bool 
	HasResult 
=>  
NativeElement! .
!=/ 1
null2 6
;6 7
} 
} Ñ
YD:\_cloud\Dropbox\Projects\SpecDrill\SpecDrill\SpecDrill.Ports\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str *
)* +
]+ ,
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
$str ,
), -
]- .
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
]$$) *