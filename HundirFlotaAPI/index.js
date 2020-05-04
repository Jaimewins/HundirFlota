var express    = require('express');        // Utilizaremos express, aqui lo mandamos llamar

var app        = express();                 // definimos la app usando express
var bodyParser = require('body-parser'); //

var UsersModel  = require('./models/userModel');
/*
UsersModel.create(
    {
    "name": "Jandu",
    "email": "cachoperro@yopmail.com"
    }
);

UsersModel.findOne({
    "email": "cachoperro@yopmail.com"},
    function (err, doc) {
        if(err){
            console.log(err);
            return;
        }

        console.log(doc.name);
        
        doc.name = "Pepito";
        doc.save(); 

        console.log(doc.name);
    }
);

UsersModel.find({
    "email": "cachoperro@yopmail.com"},
    function (err, docs) {
        if(err){
            console.log(err);
            return;
        }

        docs.forEach(doc => {
            console.log(doc.name + " "+ doc.email+ " "+ doc._id);            
        });
    }
);
*/
// configuramos la app para que use bodyParser(), esto nos dejara usar la informacion de los POST
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var port = process.env.PORT || 8080;        // seteamos el puerto

var router = express.Router();   //Creamos el router de express

// Seteamos la ruta principal
router.get('/', function(req, res) {
    res.json({ message: 'Hooolaa :)'});
});


var gameonline = express.Router();

gameonline.get('/', function(req, res) {
    res.json({ message: 'Api GameOnline :)'});
});


gameonline.post('/user', function(req,res){
        console.log("paso por user post");
        console.log(req.body);
        if(req.body.name != null && req.body.email != null){
            UsersModel.create(
                {
                "name": req.body.name,
                "email": req.body.email
                }, 
                function(err){
                    if(err){ res.end(err)}
                    else{ res.end("Usuario insertado correctamente")}
                }
            );
        }else{
            res.end('ERROR');
        }
    }
);

//======================================================
var ahorcado = express.Router();

function codifica(entrada){
    var salida="";

    for (var i = 0; i< entrada.length; i++){
        salida+="*";
    }

    return salida;
}

function existecaracter(letra, palabra){
    return palabra.indexOf(letra)>=0;
}

function procesacaractercifrado(letra){
    var actual="";
    for(var i=0; i< palabraActual.length;i++){
        if(palabraActual.charAt(i) == letra){
            actual+=letra;
        }else{
            actual+=palabraActualCifrada.charAt(i);
        }
    }
    palabraActualCifrada = actual;
}

var palabras = [ 'PEPITO', 'JUANITO', 'MARQUITO', 'BOLLICAO'];
var indicepalabra = 0;

var palabraActual = palabras[indicepalabra];
var palabraActualCifrada = codifica(palabraActual);


ahorcado.get('/currentword', function(req, res) {
    res.json({ "word": palabraActualCifrada});
});


ahorcado.post('/playword', function(req, res) {
    if(req.body.word){
        if(palabraActual == req.body.word){
            //cambiar de palabra
            indicepalabra++;
            indicepalabra%=palabras.length;  //-> indicepalabra = indicepalabra % palabras.length;
            palabraActual = palabras[indicepalabra];
            palabraActualCifrada = codifica(palabraActual);
            res.json({ "status": "WIN"});    
        }else{
            res.json({ "status": "NOOK"});
        }
    }else{
        res.json({ "status": "ERROR"});
    }
});

ahorcado.post('/playletter', function(req, res) {
    console.log(req.body.letter);
    if(req.body.letter && req.body.letter.length==1){
        if(existecaracter(req.body.letter, palabraActual)){
            //procesar palabraactualcifrada
            procesacaractercifrado(req.body.letter);
            res.json({ "status": "OK", "word": palabraActualCifrada});
        }else{
            res.json({ "status": "NOOK", "word": palabraActualCifrada});
        }
    }else{
        res.json({ "status": "ERROR"});
    }
});


// Le decimos a la aplicación que utilize las rutas que agregamos
app.use('/api', router);
app.use('/gameonline', gameonline);
app.use('/ahorcado', ahorcado);

// Iniciamos el servidor
app.listen(port);
console.log('Aplicación creada en el puerto: ' + port);