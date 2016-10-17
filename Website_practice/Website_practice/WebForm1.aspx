<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Website_practice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Bootstrap 101 Template</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <div class="navbar navbar-default navbar-fixed-top" role="navigation">
            <div class="container">
                <div class="navbar-header">
                    <button  type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span> <!-- barra de menu -->
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                      <a class="navbar-brand" href="WebForm1.aspx"> <img alt="View"src="Images/cultivo-de-la-cana-de-azucar.jpg" class="img-circle" height="46px"/>  </a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="active"><a href="WebForm1.aspx">Home</a> </li>
                        <li><a href="https://translate.google.es/?hl=es&tab=TT#en/es/toggl">Translate</a></li>
                        <li><a href="https://www.jetbrains.com/datagrip/buy/#edition=commercial">DataGrid</a></li>
                        <li class="dropdown">
                            <a href="http://stackoverflow.com/questions/35008890/bootstrap-collapsed-navbar-disappears" class="dropdown-toggle" data-toggle="dropdown" >Product <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                             <li class="dropdown-header">Test</li>
                                <li><a href="http://code.makery.ch/library/more-html-css/image-bootstrap/">Image</a></li>
                                 <li><a href="http://code.makery.ch/library/more-html-css/image-bootstrap/">Videos</a></li>
                                 <li><a href="http://code.makery.ch/library/more-html-css/image-bootstrap/">Styles</a></li>
                               <li class="dropdown-header">Test2</li>
                                    <li><a href="$">Open</a></li>
                                     <li><a href="$">Open2</a></li>                                    
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!---Carousel-->
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src="Images/30-hechos-que-no-sabias-de-los-animales-2.jpg" alt="...">
      <div class="carousel-caption">
        <h3>Tigger</h3>
    <p>Information</p>
    <p><a class="btn btn-lg btn-primary" href"http://eskipaper.com/yellow-lab-puppy-9.html#gal_post_59290_yellow-lab-puppy-9.jpg" role="button">Read More</a></p>
      </div>
    </div>
    <div class="item">
      <img src="Images/wild-animal-wallpaper-2.jpg" alt="...">
      <div class="carousel-caption">
         <h3>The new Animal!</h3>
    <p>Learn about wild animals</p>
    <p><a class="btn btn-lg btn-primary" href"http://eskipaper.com/yellow-lab-puppy-9.html#gal_post_59290_yellow-lab-puppy-9.jpg" role="button">Read More</a></p>
      </div>
    </div>
    ...
  </div>

  <!-- Controls -->
  <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>


        <!---Carousel-->

    </div>

        <!--------Middle contents-->
        <div class="row">
            <div class="col-lg-4">
                <img class="img-thumbnail"src="Images/349694045072913.jpg" alt="thmb1" width="140" height="140"/>              
                <h2>Wild Animals</h2>
                <p>Special thanks to everyone who helped and inspired us to make this record, and the band's journey until now. 
                  Thanks also to all who support and keep the DIY community alive. This release is a collaborative effort in this spirit. Much love to the labels below! </p>
                <p><a class="btn btn-default" href="%" role="button">Read More &raquo; </a></p> 
            </div>
           
                <div class="col-lg-4">
                <img class="img-thumbnail"src="Images/Wild-Animal-Wallpaper-Desktop.jpg" alt="thmb13" width="140" height="140"/>              
                <h2>Wild Animals</h2>
                <p>Special thanks to everyone who helped and inspired us to make this record, and the band's journey until now. 
                  Thanks also to all who support and keep the DIY community alive. This release is a collaborative effort in this spirit. Much love to the labels below! </p>
                   <p><a class="btn btn-default"hrf="&" role="button">Read More &raquo;</a> </p>
                 </div>

              <div class="col-lg-4">
                <img class="img-thumbnail"src="Images/leopardo-de-las-nievess_g.jpg" alt="thmb14" width="140" height="140"/>              
                <h2>Wild Animals</h2>
                <p>Martin worked as a consultant for 13 years, and has many years of experience in optimizing large customer solutions with business needs in mind. Martin focuses on Microsoft and VMware products, and he holds certifications in many Microsoft and VMware technologies. </p>
                  <p><a class="btn btn-default"hrf="#"role="button">Read More &raquo;</a></p> 
                 </div>
        </div>

       

    </form>
  

     <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>
