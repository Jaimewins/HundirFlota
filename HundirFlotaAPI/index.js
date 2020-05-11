var express    = require('express');        // Utilizaremos express, aqui lo mandamos llamar

var app        = express();                 // definimos la app usando express
var bodyParser = require('body-parser'); //

var UsersModel  = require('./models/userModel');

//======================================================
var baquitos = express.Router();


// VARIABLES
var matriz = new Array(2);

var barcoPeque = [];
var barcoMediano = [];
var barcoGrande = [];

var indexBarco = 0;
var tablaDirecciones = [0, 1, -1];
var barcoColocar = [] 

var posInitX = 0;
var posInitY = 0;

// METODOS

function ColocarBarcosPlayer(arrayBarcos){

    for (let i = 0; i < arrayBarcos.length; i++) {
        for (let j = 0; j < arrayBarcos[i].length; j++) {
            
            matriz[i][j] = arrayBarcos[i][j];
        }
    }
}


function ComprobarBarcos(x, y){
    
    var direccionX = x;
    var direccionY = y;
    
    barcoColocar.push(matrix[posInitX][posInitY]);

    for (let i = 1; i <= 2; i++) {

        if(posInitX+(i*tablaDirecciones[direccionX]) < 10 && posInitY+(i*tablaDirecciones[direccionY]) < 10 ){

            if(matrix[posInitX+(i*tablaDirecciones[direccionX])][posInitY+(i*tablaDirecciones[direccionY])] == "A"){

                barcoColocar.push(matrix[posInitX+(i*tablaDirecciones[direccionX])][posInitY+(i*tablaDirecciones[direccionY])]);
            } else {

                if(direccionY == 1 && direccionY == 0){
                    
                    barcoColocar = [] 
                    ComprobarBarcos(0, 1)
                } else if(direccionX == 0 && direccionY == 1){
                    
                    barcoColocar = [] 
                    ComprobarBarcos(2, 0)
                } else if(direccionX == 2 && direccionY == 0){
                    
                    barcoColocar = [] 
                    ComprobarBarcos(0, 2)
                } else{
                    
                    return false;
                } 
            }
        } else {

            return false;
        }
    } 

    return true;
}

function ColocarBarcosIA(){

    do{

        posInitX = Math.floor(Math.random() * 10);
        posInitY = Math.floor(Math.random() * 10);
    } while(!matrix[posInitX][posInitY] == "A")

    if(ComprobarBarcos(1, 0)){
        
        switch (indexBarco) {
            case 0:
                
                indexBarco = 1;
                barcoPeque = barcoColocar;
                barcoColocar = [] 
                ColocarBarcosIA();
                break;
            case 1:

                indexBarco = 2;
                barcoMediano = barcoColocar;
                barcoColocar = [] 
                ColocarBarcosIA();
                break;
            case 2:
        
                barcoGrande = barcoColocar;
                barcoColocar = [] 
                break;
            default:
                break;
        }

    } else {

        ColocarBarcosIA();
    }
          
}

//LLAMADAS

baquitos.get('/cargamatriz', function(req, res) {

    for (let i = 0; i < 10; i++) {
        for (let j = 0; j < 10; j++) {
            
            matriz[i][j] = "A";
        }
    }

    res.json({ "word": palabraActualCifrada});
});


baquitos.get('/colocarbarcosplayer', function(req, res) {
    if(req.body.barcos){
        
        ColocarBarcosPlayer();
        ColocarBarcosIA();
    }else{
        res.json({ "status": "ERROR"});
    }
});


baquitos.post('/disparar', function(req, res) {
    if(req.body.word){
        
        
    }else{
        res.json({ "status": "ERROR"});
    }
});


// Le decimos a la aplicación que utilize las rutas que agregamos
app.use('/baquitos', baquitos);

// Iniciamos el servidor
app.listen(port);
console.log('Aplicación creada en el puerto: ' + port);