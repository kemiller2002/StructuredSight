
function uploadImage (event) {
  var input = event.target;

  var reader = new FileReader();
  reader.onload = function () {
    var dataURL = reader.result;
    postImage(dataURL);
  }

    reader.readAsDataURL(input.files[0]);
}


function postImage (img) {
  //ocrImage('http://i.imgur.com/t4zpzAu.png');
  //return;

    $('#displayImage').attr('src', img);


    var formData = new FormData($('form')[0]);
    let clientId = 'ad65ed241de3567';
    let clientToken = `Client-ID ${clientId}`;

    console.log(clientToken);

    $.ajax({
        url: 'https://api.imgur.com/3/image',
        headers: {
            'Authorization': clientToken
        },
        type: 'POST',
        data: {
            'image': img.split(',')[1]
        },
        success: function(response) {
          console.log(response);
          ocrImage(response.data.link, response.data.deletehash);
          $("#url").text(response.data.link);
        }
    });
}

function ocrImage (url, id) {
  $.ajax({
    url: 'https://api.projectoxford.ai/vision/v1/ocr',
    headers:{
      'Ocp-Apim-Subscription-Key' : '197a2be138ac41f79ef06255d6db5a7c',
    },
    type:'POST',
    contentType:"application/json",
    data: JSON.stringify({"Url": url}),
    success: function (response) {
      console.log(response);
      deleteImage(id);
      $("#language").text(response.language);
      $("#orientation").text(response.orientation);
      let text = response
        .regions
        .map(r=>r.lines
                  .map(l=>l.words.map(w=>.text).join("<br/>")
                  .join("<br/><br/>")
            ).join("<br/><br/>")
        );

      $("#response").html(text);
    },
    error:function () {deleteImage(id);}

  })
}

function deleteImage(id){
  let clientId = 'ad65ed241de3567';
  let clientToken = `Client-ID ${clientId}`;

  $.ajax({
      url: `https://api.imgur.com/3/image/${id}`,
      headers: {
          'Authorization': clientToken
      },
      type: 'DELETE',
      success: function(response) {
        console.log(response);
      }
  });
}

function addTranslation (text) {
  $.ajax(
    {
      url: 'https://datamarket.accesscontrol.windows.net/v2/OAuth2-13',
      type: 'POST',
      jsonp: "alert",
      headers : {
          "access-control-allow-origin" : "*"
        }
        , data: {
          "grant_type":"client_credentials",
          "client_id" : "OxfordDemoApplication",
          "client_secret" : "",
          "scope" : "http://api.microsofttranslator.com"
        }
        , success : function () {alert("success;")}

      });
}
