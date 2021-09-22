Ù
J/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/AutoMapperProfile.cs
	namespace 	
ProductBackEnd
 
{ 
public 

class 
AutoMapperProfile "
:# $
Profile% ,
{		 
public

 
AutoMapperProfile

  
(

  !
)

! "
{ 	
	CreateMap 
< 
Product 
, 
GetProductDto ,
>, -
(- .
). /
;/ 0
	CreateMap 
< 
AddProductDto #
,# $
Product% ,
>, -
(- .
). /
;/ 0
	CreateMap 
< 
UpdateProductDto &
,& '
Product( /
>/ 0
(0 1
)1 2
;2 3
} 	
} 
} §
B/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Constants.cs
	namespace 	
ProductBackEnd
 
{ 
public 

static 
class 
	Constants !
{ 
public 
const 
string 
ServiceErrorMsg +
=, -
$str. E
;E F
public 
const 
string  
UpdateProductSuccess 0
=1 2
$str3 T
;T U
public 
const 
string  
DeleteProductSuccess 0
=1 2
$str3 T
;T U
} 
public

 

static

 
class

 
	ApiRoutes

 !
{ 
public 
const 
string 
	GetDetail %
=& '
$str( 4
;4 5
public 
const 
string 
GetAll "
=# $
$str% .
;. /
public 
const 
string 
CreateProduct )
=* +
$str, <
;< =
public 
const 
string 
UpdateProduct )
=* +
$str, <
;< =
public 
const 
string 
DeleteProduct )
=* +
$str, <
;< =
} 
} ˘2
V/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Controllers/ProductController.cs
	namespace 	
ProductBackEnd
 
. 
Controllers $
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
ProductController "
:# $
ControllerBase% 3
{ 
private 
readonly 
IProductService (
_productService) 8
;8 9
public 
ProductController  
(  !
IProductService! 0
productService1 ?
)? @
{ 	
_productService 
= 
productService ,
;, -
} 	
[ 	
HttpGet	 
] 
[ 	
Route	 
( 
	ApiRoutes 
. 
	GetDetail "
)" #
]# $
public 
async 
Task 
< 
ActionResult &
<& '
ServiceResponse' 6
<6 7
GetProductDto7 D
>D E
>E F
>F G
GetSingleProductH X
(X Y
[Y Z
	FromQueryZ c
(c d
Named h
=i j
$strk s
)s t
]t u
intv y
prodId	z Ä
)
Ä Å
{ 	
var 
serviceResponse 
=  !
await" '
_productService( 7
.7 8
GetProductById8 F
(F G
prodIdG M
)M N
;N O
if 
( 
serviceResponse 
. 
Data #
==$ &
null' +
)+ ,
{- .
return 
NotFound 
(  
serviceResponse  /
)/ 0
;0 1
} 
return 
Ok 
( 
serviceResponse %
)% &
;& '
}   	
["" 	
HttpGet""	 
]"" 
[## 	
Route##	 
(## 
	ApiRoutes## 
.## 
GetAll## 
)##  
]##  !
public$$ 
async$$ 
Task$$ 
<$$ 
ActionResult$$ &
<$$& '
ServiceResponse$$' 6
<$$6 7
List$$7 ;
<$$; <
GetProductDto$$< I
>$$I J
>$$J K
>$$K L
>$$L M
AllProducts$$N Y
($$Y Z
)$$Z [
{%% 	
return&& 
Ok&& 
(&& 
await&& 
_productService&& +
.&&+ ,
GetAllProducts&&, :
(&&: ;
)&&; <
)&&< =
;&&= >
}'' 	
[)) 	
HttpPost))	 
])) 
[** 	
Route**	 
(** 
	ApiRoutes** 
.** 
CreateProduct** &
)**& '
]**' (
public++ 
async++ 
Task++ 
<++ 
ActionResult++ &
<++& '
ServiceResponse++' 6
<++6 7
List++7 ;
<++; <
GetProductDto++< I
>++I J
>++J K
>++K L
>++L M

AddProduct++N X
(++X Y
AddProductDto++Y f

newProduct++g q
)++q r
{,, 	
return-- 
Ok-- 
(-- 
await-- 
_productService-- +
.--+ ,

AddProduct--, 6
(--6 7

newProduct--7 A
)--A B
)--B C
;--C D
}.. 	
[00 	
HttpPut00	 
]00 
[11 	
Route11	 
(11 
	ApiRoutes11 
.11 
UpdateProduct11 &
)11& '
]11' (
public22 
async22 
Task22 
<22 
ActionResult22 &
<22& '
ServiceResponse22' 6
<226 7
GetProductDto227 D
>22D E
>22E F
>22F G
UpdateProduct22H U
(22U V
[22V W
	FromQuery22W `
(22` a
Name22a e
=22f g
$str22h p
)22p q
]22q r
int22s v
prodId22w }
,22} ~
UpdateProductDto	22 è
updateProduct
22ê ù
)
22ù û
{
22ü †
var44 
serviceResponse44 
=44  !
await44" '
_productService44( 7
.447 8
UpdateProduct448 E
(44E F
prodId44F L
,44L M
updateProduct44N [
)44[ \
;44\ ]
if66 
(66 
serviceResponse66 
.66 
Data66 #
==66$ &
null66' +
)66+ ,
{66- .
return77 
NotFound77 
(77  
serviceResponse77  /
)77/ 0
;770 1
}88 
return:: 
Ok:: 
(:: 
serviceResponse:: %
)::% &
;::& '
};; 	
[== 	

HttpDelete==	 
]== 
[>> 	
Route>>	 
(>> 
	ApiRoutes>> 
.>> 
DeleteProduct>> &
)>>& '
]>>' (
public?? 
async?? 
Task?? 
<?? 
ActionResult?? &
<??& '
ServiceResponse??' 6
<??6 7
List??7 ;
<??; <
GetProductDto??< I
>??I J
>??J K
>??K L
>??L M
DeleteProudct??N [
(??[ \
[??\ ]
	FromQuery??] f
(??f g
Name??g k
=??l m
$str??n v
)??v w
]??w x
int??y |
prodId	??} É
)
??É Ñ
{
??Ö Ü
varAA 
serviceResponseAA 
=AA  !
awaitAA" '
_productServiceAA( 7
.AA7 8
DeleteProductAA8 E
(AAE F
prodIdAAF L
)AAL M
;AAM N
ifCC 
(CC 
serviceResponseCC 
.CC 
DataCC #
==CC$ &
nullCC' +
)CC+ ,
{CC- .
returnDD 
NotFoundDD 
(DD  
serviceResponseDD  /
)DD/ 0
;DD0 1
}EE 
returnGG 
OkGG 
(GG 
serviceResponseGG %
)GG% &
;GG& '
}HH 	
}II 
}JJ ƒ
N/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Data/InventoryContext.cs
	namespace 	
ProductBackEnd
 
. 
Data 
{ 
public 

class 
InventoryContext !
:" #
	DbContext$ -
{ 
public 
InventoryContext 
(  
DbContextOptions  0
<0 1
InventoryContext1 A
>A B
optionsC J
)J K
:L M
baseN R
(R S
optionsS Z
)Z [
{		 	
} 	
public 
DbSet 
< 
Product 
> 
Products &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
} 
} Å
[/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Data/Repository/IProductRepository.cs
	namespace 	
ProductBackEnd
 
. 
Data 
. 

Repository (
{ 
public 

	interface 
IProductRepository '
:( )
IRepository* 5
{ 
} 
} ∫

T/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Data/Repository/IRepository.cs
	namespace 	
ProductBackEnd
 
. 
Data 
. 

Repository (
{ 
public		 

	interface		 
IRepository		  
{

 
Task 
< 
List 
< 
Product 
> 
> 
GetAllproducts *
(* +
)+ ,
;, -
Task 
< 
Product 
> 
GetProductById $
($ %
int% (
prodId) /
)/ 0
;0 1
Task 
< 
List 
< 
Product 
> 
> 

AddProduct &
(& '
Product' .

newProduct/ 9
)9 :
;: ;
Task 
< 
bool 
> 
UpdateProduct  
(  !
int! $
prodId% +
,+ ,
Product- 4
product5 <
)< =
;= >
Task 
< 
bool 
> 
DeleteProduct  
(  !
int! $
prodId% +
)+ ,
;, -
} 
} í-
Z/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Data/Repository/ProductRepository.cs
	namespace 	
ProductBackEnd
 
. 
Data 
. 

Repository (
{		 
public

 

class

 
ProductRepository

 "
:

# $
IProductRepository

% 7
{ 
private 
readonly 
InventoryContext )
_inventoryContext* ;
;; <
public 
ProductRepository  
(  !
InventoryContext! 1
inventoryContext2 B
)B C
{ 	
_inventoryContext 
= 
inventoryContext  0
;0 1
} 	
public 
async 
Task 
< 
List 
< 
Product &
>& '
>' (
GetAllproducts) 7
(7 8
)8 9
{ 	
return 
await 
_inventoryContext *
.* +
Products+ 3
.3 4
ToListAsync4 ?
(? @
)@ A
;A B
} 	
public 
async 
Task 
< 
Product !
>! "
GetProductById# 1
(1 2
int2 5
prodId6 <
)< =
{ 	
return 
await 
_inventoryContext *
.* +
Products+ 3
.3 4
FirstOrDefaultAsync4 G
(G H
pH I
=>J L
pM N
.N O
	ProductIdO X
==Y [
prodId\ b
)b c
;c d
} 	
public 
async 
Task 
< 
List 
< 
Product &
>& '
>' (

AddProduct) 3
(3 4
Product4 ;

newProduct< F
)F G
{ 	
_inventoryContext 
. 
Products &
.& '
Add' *
(* +

newProduct+ 5
)5 6
;6 7
await   
_inventoryContext   #
.  # $
SaveChangesAsync  $ 4
(  4 5
)  5 6
;  6 7
return"" 
await"" 
_inventoryContext"" *
.""* +
Products""+ 3
.""3 4
ToListAsync""4 ?
(""? @
)""@ A
;""A B
}## 	
public%% 
async%% 
Task%% 
<%% 
bool%% 
>%% 
DeleteProduct%%  -
(%%- .
int%%. 1
prodId%%2 8
)%%8 9
{&& 	
try'' 
{(( 
Product)) 
product)) 
=))  !
await))" '
_inventoryContext))( 9
.))9 :
Products)): B
.))B C

FirstAsync))C M
())M N
p))N O
=>))P R
p))S T
.))T U
	ProductId))U ^
==))_ a
prodId))b h
)))h i
;))i j
_inventoryContext** !
.**! "
Products**" *
.*** +
Remove**+ 1
(**1 2
product**2 9
)**9 :
;**: ;
await,, 
_inventoryContext,, '
.,,' (
SaveChangesAsync,,( 8
(,,8 9
),,9 :
;,,: ;
return.. 
true.. 
;.. 
}// 
catch00 
(00 
	Exception00 
ex00 
)00  
{11 
Console22 
.22 
Write22 
(22 
$str22 :
+22; <
ex22= ?
.22? @
Message22@ G
)22G H
;22H I
}33 
return55 
false55 
;55 
}66 	
public88 
async88 
Task88 
<88 
bool88 
>88 
UpdateProduct88  -
(88- .
int88. 1
prodId882 8
,888 9
Product88: A
product88B I
)88I J
{99 	
Product:: 
	dbProduct:: 
=:: 
await::  %
_inventoryContext::& 7
.::7 8
Products::8 @
.::@ A
FirstOrDefaultAsync::A T
(::T U
p::U V
=>::W Y
p::Z [
.::[ \
	ProductId::\ e
==::f h
prodId::i o
)::o p
;::p q
if<< 
(<< 
	dbProduct<< 
!=<< 
null<<  
)<<  !
{== 
	dbProduct>> 
.>> 
Name>> 
=>>  
product>>! (
.>>( )
Name>>) -
;>>- .
	dbProduct?? 
.?? 
Description?? %
=??& '
product??( /
.??/ 0
Description??0 ;
;??; <
	dbProduct@@ 
.@@ 
Rating@@  
=@@! "
product@@# *
.@@* +
Rating@@+ 1
;@@1 2
	dbProductAA 
.AA 
PriceAA 
=AA  !
productAA" )
.AA) *
PriceAA* /
;AA/ 0
	dbProductBB 
.BB 
ImageBB 
=BB  !
productBB" )
.BB) *
ImageBB* /
;BB/ 0
	dbProductCC 
.CC 
ReviewsCC !
=CC" #
productCC$ +
.CC+ ,
ReviewsCC, 3
;CC3 4
awaitEE 
_inventoryContextEE '
.EE' (
SaveChangesAsyncEE( 8
(EE8 9
)EE9 :
;EE: ;
returnGG 
trueGG 
;GG 
}HH 
returnJJ 
falseJJ 
;JJ 
}KK 	
}LL 
}MM ˙
S/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Dtos/Product/AddProductDto.cs
	namespace 	
ProductBackEnd
 
. 
Dtos 
. 
Product %
{ 
public 

class 
AddProductDto 
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
$str+ -
;- .
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
$str2 4
;4 5
public 
int 
Rating 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
public 
int 
Price 
{ 
get 
; 
set  #
;# $
}% &
=' (
$num) *
;* +
public		 
string		 
Image		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
$str		, .
;		. /
public

 
int

 
Reviews

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
=

) *
$num

+ ,
;

, -
} 
} î
S/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Dtos/Product/GetProductDto.cs
	namespace 	
ProductBackEnd
 
. 
Dtos 
. 
Product %
{ 
public 

class 
GetProductDto 
{ 
public 
int 
	ProductId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
$str+ -
;- .
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
$str2 4
;4 5
public 
int 
Rating 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
public		 
int		 
Price		 
{		 
get		 
;		 
set		  #
;		# $
}		% &
=		' (
$num		) *
;		* +
public

 
string

 
Image

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
=

* +
$str

, .
;

. /
public 
int 
Reviews 
{ 
get  
;  !
set" %
;% &
}' (
=) *
$num+ ,
;, -
} 
} Ä
V/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Dtos/Product/UpdateProductDto.cs
	namespace 	
ProductBackEnd
 
. 
Dtos 
. 
Product %
{ 
public 

class 
UpdateProductDto !
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
$str+ -
;- .
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
$str2 4
;4 5
public 
int 
Rating 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
public 
int 
Price 
{ 
get 
; 
set  #
;# $
}% &
=' (
$num) *
;* +
public		 
string		 
Image		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
$str		, .
;		. /
public

 
int

 
Reviews

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
=

) *
$num

+ ,
;

, -
} 
} ﬂ
`/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Migrations/20210813120353_InitialCreate.cs
	namespace 	
ProductBackEnd
 
. 

Migrations #
{ 
public 

partial 
class 
InitialCreate &
:' (
	Migration) 2
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder		 
.		 
CreateTable		 (
(		( )
name

 
:

 
$str

  
,

  !
columns 
: 
table 
=> !
new" %
{ 
	ProductId 
= 
table  %
.% &
Column& ,
<, -
int- 0
>0 1
(1 2
type2 6
:6 7
$str8 =
,= >
nullable? G
:G H
falseI N
)N O
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
,A B
Name 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 E
,E F
nullableG O
:O P
trueQ U
)U V
,V W
Description 
=  !
table" '
.' (
Column( .
<. /
string/ 5
>5 6
(6 7
type7 ;
:; <
$str= L
,L M
nullableN V
:V W
trueX \
)\ ]
,] ^
Rating 
= 
table "
." #
Column# )
<) *
int* -
>- .
(. /
type/ 3
:3 4
$str5 :
,: ;
nullable< D
:D E
falseF K
)K L
,L M
Price 
= 
table !
.! "
Column" (
<( )
int) ,
>, -
(- .
type. 2
:2 3
$str4 9
,9 :
nullable; C
:C D
falseE J
)J K
,K L
Image 
= 
table !
.! "
Column" (
<( )
string) /
>/ 0
(0 1
type1 5
:5 6
$str7 F
,F G
nullableH P
:P Q
trueR V
)V W
,W X
Reviews 
= 
table #
.# $
Column$ *
<* +
int+ .
>. /
(/ 0
type0 4
:4 5
$str6 ;
,; <
nullable= E
:E F
falseG L
)L M
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 2
,2 3
x4 5
=>6 8
x9 :
.: ;
	ProductId; D
)D E
;E F
} 
) 
; 
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str  
)  !
;! "
}   	
}!! 
}"" ‡
G/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Models/Product.cs
	namespace 	
ProductBackEnd
 
. 
Models 
{ 
public 

class 
Product 
{ 
public 
int 
	ProductId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
$str+ -
;- .
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
$str2 4
;4 5
public 
int 
Rating 
{ 
get 
;  
set! $
;$ %
}& '
=( )
$num* +
;+ ,
public		 
int		 
Price		 
{		 
get		 
;		 
set		  #
;		# $
}		% &
=		' (
$num		) *
;		* +
public

 
string

 
Image

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
=

* +
$str

, .
;

. /
public 
int 
Reviews 
{ 
get  
;  !
set" %
;% &
}' (
=) *
$num+ ,
;, -
} 
} ı
O/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Models/ServiceResponse.cs
	namespace 	
ProductBackEnd
 
. 
Models 
{ 
public 

class 
ServiceResponse  
<  !
T! "
>" #
{ 
public 
T 
Data 
{ 
get 
; 
set  
;  !
}" #
public 
bool 
Success 
{ 
get !
;! "
set# &
;& '
}( )
=* +
true, 0
;0 1
public		 
string		 
message		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
$str		. 0
;		0 1
}

 
} ú

@/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Program.cs
	namespace

 	
ProductBackEnd


 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} ‚
`/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Services/ProductService/IProductService.cs
	namespace 	
ProductBackEnd
 
. 
Services !
.! "
ProductService" 0
{ 
public 

	interface 
IProductService $
{		 
Task

	 
<

 
ServiceResponse

 
<

 
List

 "
<

" #
GetProductDto

# 0
>

0 1
>

1 2
>

2 3
GetAllProducts

4 B
(

B C
)

C D
;

D E
Task	 
< 
ServiceResponse 
< 
GetProductDto +
>+ ,
>, -
GetProductById. <
(< =
int= @
prodIdA G
)G H
;H I
Task	 
< 
ServiceResponse 
< 
List "
<" #
GetProductDto# 0
>0 1
>1 2
>2 3

AddProduct4 >
(> ?
AddProductDto? L

newProductM W
)W X
;X Y
Task	 
< 
ServiceResponse 
< 
GetProductDto +
>+ ,
>, -
UpdateProduct. ;
(; <
int< ?
prodId@ F
,F G
UpdateProductDtoH X
updateProductY f
)f g
;g h
Task	 
< 
ServiceResponse 
< 
List "
<" #
GetProductDto# 0
>0 1
>1 2
>2 3
DeleteProduct4 A
(A B
intB E
prodIdF L
)L M
;M N
} 
} ∏R
_/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Services/ProductService/ProductService.cs
	namespace		 	
ProductBackEnd		
 
.		 
Services		 !
.		! "
ProductService		" 0
{

 
public 

class 
ProductService 
:  !
IProductService" 1
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IProductRepository +
_productRepository, >
;> ?
public 
ProductService 
( 
IMapper %
mapper& ,
,, -
IProductRepository. @
productRepositoryA R
)R S
{ 	
_productRepository 
=  
productRepository! 2
;2 3
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
ServiceResponse )
<) *
List* .
<. /
GetProductDto/ <
>< =
>= >
>> ?

AddProduct@ J
(J K
AddProductDtoK X

newProductY c
)c d
{ 	
var 
serviceResponse 
=  !
new" %
ServiceResponse& 5
<5 6
List6 :
<: ;
GetProductDto; H
>H I
>I J
(J K
)K L
;L M
Product 
product 
= 
_mapper %
.% &
Map& )
<) *
Product* 1
>1 2
(2 3

newProduct3 =
)= >
;> ?
List 
< 
Product 
> 

dbProducts $
=% &
await' ,
_productRepository- ?
.? @

AddProduct@ J
(J K
productK R
)R S
;S T
serviceResponse 
. 
Data  
=! "
_mapper# *
.* +
Map+ .
<. /
List/ 3
<3 4
GetProductDto4 A
>A B
>B C
(C D

dbProductsD N
)N O
;O P
return 
serviceResponse "
;" #
}   	
public"" 
async"" 
Task"" 
<"" 
ServiceResponse"" )
<"") *
List""* .
<"". /
GetProductDto""/ <
>""< =
>""= >
>""> ?
GetAllProducts""@ N
(""N O
)""O P
{## 	
var$$ 
serviceResponse$$ 
=$$  !
new$$" %
ServiceResponse$$& 5
<$$5 6
List$$6 :
<$$: ;
GetProductDto$$; H
>$$H I
>$$I J
($$J K
)$$K L
;$$L M
List&& 
<&& 
Product&& 
>&& 

dbProducts&& $
=&&% &
await&&' ,
_productRepository&&- ?
.&&? @
GetAllproducts&&@ N
(&&N O
)&&O P
;&&P Q
serviceResponse(( 
.(( 
Data((  
=((! "
_mapper((# *
.((* +
Map((+ .
<((. /
List((/ 3
<((3 4
GetProductDto((4 A
>((A B
>((B C
(((C D

dbProducts((D N
)((N O
;((O P
return** 
serviceResponse** "
;**" #
}++ 	
public-- 
async-- 
Task-- 
<-- 
ServiceResponse-- )
<--) *
GetProductDto--* 7
>--7 8
>--8 9
GetProductById--: H
(--H I
int--I L
prodId--M S
)--S T
{.. 	
var// 
serviceResponse// 
=//  !
new//" %
ServiceResponse//& 5
<//5 6
GetProductDto//6 C
>//C D
(//D E
)//E F
;//F G
var11 
	dbProduct11 
=11 
await11 !
_productRepository11" 4
.114 5
GetProductById115 C
(11C D
prodId11D J
)11J K
;11K L
if33 
(33 
	dbProduct33 
==33 
null33  
)33  !
{33" #
serviceResponse44 
.44  
message44  '
=44( )
	Constants44* 3
.443 4
ServiceErrorMsg444 C
;44C D
serviceResponse55 
.55  
Success55  '
=55( )
false55* /
;55/ 0
}66 
else77 
{77 
serviceResponse88 
.88  
Data88  $
=88% &
_mapper88' .
.88. /
Map88/ 2
<882 3
GetProductDto883 @
>88@ A
(88A B
	dbProduct88B K
)88K L
;88L M
}99 
return;; 
serviceResponse;; "
;;;" #
}<< 	
public>> 
async>> 
Task>> 
<>> 
ServiceResponse>> )
<>>) *
GetProductDto>>* 7
>>>7 8
>>>8 9
UpdateProduct>>: G
(>>G H
int>>H K
prodId>>L R
,>>R S
UpdateProductDto>>T d
updateProduct>>e r
)>>r s
{?? 	
var@@ 
serviceResponse@@ 
=@@  !
new@@" %
ServiceResponse@@& 5
<@@5 6
GetProductDto@@6 C
>@@C D
(@@D E
)@@E F
;@@F G
ProductBB 
productBB 
=BB 
_mapperBB %
.BB% &
MapBB& )
<BB) *
ProductBB* 1
>BB1 2
(BB2 3
updateProductBB3 @
)BB@ A
;BBA B
productCC 
.CC 
	ProductIdCC 
=CC 
prodIdCC  &
;CC& '
tryEE 
{FF 
boolGG 
isProductUpdatedGG %
=GG& '
awaitGG( -
_productRepositoryGG. @
.GG@ A
UpdateProductGGA N
(GGN O
prodIdGGO U
,GGU V
productGGW ^
)GG^ _
;GG_ `
ifII 
(II 
!II 
isProductUpdatedII %
)II% &
{JJ 
serviceResponseKK #
.KK# $
messageKK$ +
=KK, -
	ConstantsKK. 7
.KK7 8
ServiceErrorMsgKK8 G
;KKG H
serviceResponseLL #
.LL# $
SuccessLL$ +
=LL, -
falseLL. 3
;LL3 4
}MM 
elseNN 
{OO 
serviceResponsePP #
.PP# $
DataPP$ (
=PP) *
_mapperPP+ 2
.PP2 3
MapPP3 6
<PP6 7
GetProductDtoPP7 D
>PPD E
(PPE F
productPPF M
)PPM N
;PPN O
serviceResponseQQ #
.QQ# $
messageQQ$ +
=QQ, -
	ConstantsQQ. 7
.QQ7 8 
UpdateProductSuccessQQ8 L
;QQL M
}RR 
}SS 
catchTT 
(TT 
	ExceptionTT 
exTT 
)TT  
{UU 
ConsoleVV 
.VV 
WriteVV 
(VV 
$strVV 7
+VV8 9
exVV: <
.VV< =
MessageVV= D
)VVD E
;VVE F
serviceResponseWW 
.WW  
messageWW  '
=WW( )
	ConstantsWW* 3
.WW3 4
ServiceErrorMsgWW4 C
;WWC D
serviceResponseXX 
.XX  
SuccessXX  '
=XX( )
falseXX* /
;XX/ 0
}YY 
return[[ 
serviceResponse[[ "
;[[" #
}\\ 	
public^^ 
async^^ 
Task^^ 
<^^ 
ServiceResponse^^ )
<^^) *
List^^* .
<^^. /
GetProductDto^^/ <
>^^< =
>^^= >
>^^> ?
DeleteProduct^^@ M
(^^M N
int^^N Q
prodId^^R X
)^^X Y
{__ 	
var`` 
serviceResponse`` 
=``  !
new``" %
ServiceResponse``& 5
<``5 6
List``6 :
<``: ;
GetProductDto``; H
>``H I
>``I J
(``J K
)``K L
;``L M
trybb 
{cc 
booldd 
isProductDeleteddd %
=dd& '
awaitdd( -
_productRepositorydd. @
.dd@ A
DeleteProductddA N
(ddN O
prodIdddO U
)ddU V
;ddV W
ifff 
(ff 
isProductDeletedff $
)ff$ %
{gg 
Listhh 
<hh 
Producthh  
>hh  !

dbProductshh" ,
=hh- .
awaithh/ 4
_productRepositoryhh5 G
.hhG H
GetAllproductshhH V
(hhV W
)hhW X
;hhX Y
serviceResponsejj #
.jj# $
Datajj$ (
=jj) *
_mapperjj+ 2
.jj2 3
Mapjj3 6
<jj6 7
Listjj7 ;
<jj; <
GetProductDtojj< I
>jjI J
>jjJ K
(jjK L

dbProductsjjL V
)jjV W
;jjW X
serviceResponsekk #
.kk# $
messagekk$ +
=kk, -
	Constantskk. 7
.kk7 8 
DeleteProductSuccesskk8 L
;kkL M
}ll 
elsemm 
{nn 
serviceResponseoo #
.oo# $
Successoo$ +
=oo, -
falseoo. 3
;oo3 4
serviceResponsepp #
.pp# $
messagepp$ +
=pp, -
	Constantspp. 7
.pp7 8
ServiceErrorMsgpp8 G
;ppG H
}qq 
}rr 
catchss 
(ss 
	Exceptionss 
exss 
)ss  
{tt 
Consoleuu 
.uu 
Writeuu 
(uu 
$struu 7
+uu8 9
exuu: <
.uu< =
Messageuu= D
)uuD E
;uuE F
serviceResponsevv 
.vv  
Successvv  '
=vv( )
falsevv* /
;vv/ 0
serviceResponseww 
.ww  
messageww  '
=ww( )
	Constantsww* 3
.ww3 4
ServiceErrorMsgww4 C
;wwC D
}xx 
returnzz 
serviceResponsezz "
;zz" #
}{{ 	
}|| 
}}} Ó$
@/Users/faisalhameed/Desktop/ADF/DotNet/ProductBackEnd/Startup.cs
	namespace 	
ProductBackEnd
 
{ 
public 

class 
Startup 
{ 
readonly 
string "
MyAllowSpecificOrigins .
=/ 0
$str1 J
;J K
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public!! 
void!! 
ConfigureServices!! %
(!!% &
IServiceCollection!!& 8
services!!9 A
)!!A B
{"" 	
services$$ 
.$$ 
AddCors$$ 
($$ 
options$$ $
=>$$% '
{%% 	
options&& 
.&& 
	AddPolicy&& 
(&& 
name&& "
:&&" #"
MyAllowSpecificOrigins&&$ :
,&&: ;
builder'' %
=>''& (
{(( 
builder))" )
.))) *
WithOrigins))* 5
())5 6
$str))6 M
)))M N
;))N O
}** 
)**  
;**  !
}++ 	
)++	 

;++
 
services-- 
.-- 
AddDbContext-- !
<--! "
InventoryContext--" 2
>--2 3
(--3 4
options--4 ;
=>--< >
options.. 
... 
UseSqlServer.. $
(..$ %
Configuration..% 2
...2 3
GetConnectionString..3 F
(..F G
$str..G Z
)..Z [
)..[ \
)..\ ]
;..] ^
services// 
.// 
AddControllers// #
(//# $
)//$ %
;//% &
services00 
.00 
AddSwaggerGen00 "
(00" #
c00# $
=>00% '
{11 
c22 
.22 

SwaggerDoc22 
(22 
$str22 !
,22! "
new22# &
OpenApiInfo22' 2
{223 4
Title225 :
=22; <
$str22= M
,22M N
Version22O V
=22W X
$str22Y ]
}22^ _
)22_ `
;22` a
}33 
)33 
;33 
services55 
.55 
AddAutoMapper55 "
(55" #
typeof55# )
(55) *
Startup55* 1
)551 2
)552 3
;553 4
services66 
.66 
	AddScoped66 
<66 
IProductService66 .
,66. /
ProductService660 >
>66> ?
(66? @
)66@ A
;66A B
services77 
.77 
	AddScoped77 
<77 
IProductRepository77 1
,771 2
ProductRepository773 D
>77D E
(77E F
)77F G
;77G H
}88 	
public;; 
void;; 
	Configure;; 
(;; 
IApplicationBuilder;; 1
app;;2 5
,;;5 6
IWebHostEnvironment;;7 J
env;;K N
);;N O
{<< 	
if== 
(== 
env== 
.== 
IsDevelopment== !
(==! "
)==" #
)==# $
{>> 
app?? 
.?? %
UseDeveloperExceptionPage?? -
(??- .
)??. /
;??/ 0
app@@ 
.@@ 

UseSwagger@@ 
(@@ 
)@@  
;@@  !
appAA 
.AA 
UseSwaggerUIAA  
(AA  !
cAA! "
=>AA# %
cAA& '
.AA' (
SwaggerEndpointAA( 7
(AA7 8
$strAA8 R
,AAR S
$strAAT g
)AAg h
)AAh i
;AAi j
}BB 
appDD 
.DD 
UseHttpsRedirectionDD #
(DD# $
)DD$ %
;DD% &
appFF 
.FF 

UseRoutingFF 
(FF 
)FF 
;FF 
appHH 
.HH 
UseCorsHH 
(HH "
MyAllowSpecificOriginsHH .
)HH. /
;HH/ 0
appJJ 
.JJ 
UseAuthorizationJJ  
(JJ  !
)JJ! "
;JJ" #
appLL 
.LL 
UseEndpointsLL 
(LL 
	endpointsLL &
=>LL' )
{MM 
	endpointsNN 
.NN 
MapControllersNN (
(NN( )
)NN) *
;NN* +
}OO 
)OO 
;OO 
}PP 	
}QQ 
}RR 