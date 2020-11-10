
window.onerror = function (msg, url, line, col, error) {
   // Note that col & error are new to the HTML 5 spec and may not be 
   // supported in every browser.  It worked for me in Chrome.
   var extra = !col ? '' : '\ncolumn: ' + col;
   extra += !error ? '' : '\nerror: ' + error;

   // You can view the information in an alert to see things working like this:
   alert("Error: " + msg + "\nurl: " + url + "\nline: " + line + extra);

   // TODO: Report this error via ajax so you can keep track
   //       of what pages have JS issues

   var suppressErrorAlert = true;
   // If you return true, then error alerts (like in older versions of 
   // Internet Explorer) will be suppressed.
   return suppressErrorAlert;
};

$(document).ready(function () {

   $("#logo").click(function () {
      window.location.href = "/";
   });

   $(".validation-summary-errors").click(function () {
      $(this).fadeOut('fast');
   });

   $("#search_inp").focus(function () {
      $("#search").css('border-color', '#4285F4');
   });

   $("#search_inp").blur(function () {
      $("#search").css('border-color', '#ccc');
   });

   $(".closepuWin").click(function () {
      $(".puWinBg").fadeOut("fast");
   });

   $.ajaxSetup({
      type: "POST",
      async: false,
      global: false,
      cache: true,
      statusCode:
      {
         404: function () {
            alert("Страница не найдена");
         }
      },
      error: function (data) {
         alert("Запрос не удался: " + data.responseText);
      }
   });

});

function showAvatarItems() {
   $("#deleteAvatar").css('display', 'block');
   $('#uploadAvatar').css('opacity', '1');
   $('#uploadAvatar').css('height', '32px')
}

function hideAvatarItems() {
   $("#deleteAvatar").css('display', 'none');
   $('#uploadAvatar').css('opacity', '0');
   $('#uploadAvatar').css('height', '0')
}

function uploadAvatar() {
   $("#avatarImageFile").trigger("click");
}

function deleteAvatar() {
   var r = confirm("Вы уверены что хотите удалить это фото?");
   if (r) {
      document.getElementById("deleteAvatarForm").submit();
   }
   else {
      return;
   }
}

/*
function followLink(event, link)
{
    var nameLink = link.innerHTML;
    uploadContent(link.href);
    history.pushState({title:nameLink, href:link.href}, null, link.href);
    updateTitle(nameLink);
    event.preventDefault();
}

function updateTitle(title)
{
    var elm = document.getElementsByTagName('title')[0];
    elm.innerHTML = title;
}

function uploadContent(link)
{
     $.ajax
     ({
        url: link,
        success: function (html) {
        $("#right_col").html(html);
        }
    });
}

window.addEventListener("popstate", function (e) {
    uploadContent(e.state.href);
    updateTitle(e.state.title);
}, false);
*/

//function addArticle(form) {
//   if (form.validate().checkForm() == false) return;

//   var formData = new FormData();
//   var formArr = form.serializeArray();

//   $.each(formArr, function (i, v) {
//      formData.append(v.name, v.value);
//   });

//   var files = $("#art_file").get(0).files;
//   if (files.length > 0) {
//      formData.append("File", files[0]);
//   }

//   $.ajax({
//      url: "/Home/AddArticle",
//      processData: false,
//      contentType: false,
//      data: formData,
//      success: function (response) {
//         closeForm();
//         $('#get_publs_all').trigger('click');
//      }
//   });
//}

function deleteProfile() {
   var r = confirm("Вы уверенны в своем решении? \nПосле подтверждения ваша учетная запись и все что связано с ней\nбудет безвозвратно удалено.\nПродолжить?");
   if (r) {

      document.getElementById("delProfileForm").submit();

   } else {
      return;
   }
}

function validateEmail(email) {
   var re = /^[_A-Za-z0-9-]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9]+(\.[A-Za-z0-9]+)*(\.[A-Za-z]{2,})$/;
   return re.test(email);
}

function closeForm() {
   $(".closepuWin").trigger("click");
   $(".puWinCont").html("");
}

$(document).click(function (event) {
   if ($(event.target).closest(".toolTip2").length || $(event.target).closest(".showToolTip2").length) {
      return;
   }
   else {
      $(".toolTip2").fadeOut("fast");
      event.stopPropagation();
   }
});

function showToolTip(id) {
   $("#" + id).fadeIn("fast");
}

function AddSubjectRow() {
   var subjRow = "<tr> \
         <td> \
            <div class='editInput'> \
               <input type='text' name='subj[]' value=''/> \
            </div> \
         </td> \
         <td> \
            <div class='editInput'> \
               <select name='subjH[]' style='width: 100px'> \
                  <option value='' selected='1'></option> \
                  <option value='1'>1 ч.</option>\
                  <option value='2'>2 ч.</option>\
                  <option value='3'>3 ч.</option>\
                  <option value='4'>4 ч.</option>\
                  <option value='5'>5 ч.</option>\
                  <option value='6'>6 ч.</option>\
                  <option value='7'>7 ч.</option>\
                  <option value='8'>8 ч.</option>\
                  <option value='9'>9 ч.</option>\
                  <option value='10'>10 ч.</option>\
               </select>\
            </div>\
         </td> \
         <td  style='vertical-align: top;padding-top: 6px;padding-left: 10px;'>\
            <a style='color: #3E7091;'  href='javascript:' onclick='$(this).parent().parent().remove()'>Удалить</a>\
         </td>\
      </tr>";

   $("#subjectsGrid tbody").append(subjRow)
}

function PublicationTypeSelected(publType) {

   if (publType == 0) {
      closeForm();
      return;
   }

   switch (parseInt(publType)) {

      case 1:
         $('.puWinTitle').html('Выберите тип Монографии');
         $('.puWinCont').html($('.puCont#selectMonographType').html());
         break;
      case 2:
      case 3:
         switch (parseInt(publType)) {
            case 2:
               $('.puWinTitle').html('Выберите тип Учебника');
               break;
            case 3:
               $('.puWinTitle').html('Выберите тип Пособия');
               break;
         }
         $('.puWinCont').html($('.puCont#selectSchoolBookType').html());
         $('#schoolBookType2').val(publType);
         break;
      case 4:
         $('.puWinTitle').html('Добавить методич. рекомендацию');
         $('.puWinCont').html($('.puCont#addGuideLineCont').html());
         break;
      case 5:
         $('.puWinTitle').html('Выберите тип статьи');
         $('.puWinCont').html($('.puCont#selectArticleType').html());
         break;
      case 6:
         $('.puWinTitle').html('Добавить тези доповідей');
         $('.puWinCont').html($('.puCont#addLectureThesesCont').html());
         break;

   }

}

function MOHGryphTypeSelected(MOHGryphType, schoolBookType2) {

   if (MOHGryphType == 0) {
      closeForm();
      return;
   }

   switch (parseInt(schoolBookType2)) {
      case 2:
         $('.puWinTitle').html('Добавить учебник');
         $('.puWinCont').html($('.puCont#addSchoolBookCont').html());
      case 3:
         $('.puWinTitle').html('Добавить пособие');
         $('.puWinCont').html($('.puCont#addTutorialCont').html());
         break;
      case 4:
         $('.puWinTitle').html('Добавить методич. рекомендацию');
         $('.puWinCont').html($('.puCont#addGuideLineCont').html());
         break;
   }

   $("#SchoolBookType").val(1);
   $("#SchoolBookMOHGryphType").val(MOHGryphType);

}

function MonographTypeSelected(monographType) {

   if (monographType == 0) {
      closeForm();
      return;
   }

   switch (parseInt(monographType)) {
      case 1:
      case 2:
      case 3:

         $('.puWinTitle').html('Добавить монографию');
         $('.puWinCont').html($('.puCont#addMonographCont').html());

         $("#MonographType").val(monographType);

         break;

   }
}

// SchoolBookType2 means is it Guideline , Tutorial or schoolbook
function SchoolBookTypeSelected(schoolBookType, schoolBookType2) {

   if (schoolBookType == 0) {
      closeForm();
      return;
   }

   switch (parseInt(schoolBookType)) {

      case 1:
         $('.puWinTitle').html('Выберите тип грифа МОН');
         $('.puWinCont').html($('.puCont#selectMOHGryphType').html());

         $("#schoolBookType3").val(schoolBookType2);
         break;
      case 2:
      case 3:
         switch (parseInt(schoolBookType2)) {
            case 2:
               $('.puWinTitle').html('Добавить учебник');
               $('.puWinCont').html($('.puCont#addSchoolBookCont').html());
               break;
            case 3:
               $('.puWinTitle').html('Добавить пособие');
               $('.puWinCont').html($('.puCont#addTutorialCont').html());
               break;
            case 4:
               $('.puWinTitle').html('Добавить методич. рекомендацию');
               $('.puWinCont').html($('.puCont#addGuideLineCont').html());
               break;
         }

         $("#SchoolBookType").val(schoolBookType);
         $("#schoolBookType2").val(schoolBookType2);
         break;

   }

}

function ArticleTypeSelected(articleType) {

   if (articleType == 0) {
      closeForm();
      return;
   }

   $('.puWinTitle').html('Добавить статью');
   $('.puWinCont').html($('.puCont#addArticleCont').html());

   switch (parseInt(articleType)) {

      case 1:
      case 2:
         $("#FieldScientometricDB").css('display', 'block');
         $("#FieldSNIPIndex").css('display', 'block');
         break;
      case 3:
      case 4:
      case 5:

         $("#FieldScientometricDB").css('display', 'none');
         $("#FieldSNIPIndex").css('display', 'none');
         break;

   }

   $("#ArticleType").val(articleType);

}

function IncreaseQualTypeSelected(increaseQualType) {

   if (increaseQualType == 0) {
      closeForm();
      return;
   }

   $('.puWinTitle').html('Добавить повыш. квалиф.');
   $('.puWinCont').html($('.puCont#addIncreaseQualInfoCont').html());

   switch (parseInt(increaseQualType)) {
      case 1:
      case 2:
         $("#FieldInternshipTheme").css('display', 'block');
         break;
      case 3:      
      case 4:
         $("#FieldInternshipTheme").css('display', 'none');
         break;
   }

   $("#IncreaseQualInfoType").val(increaseQualType);
}

function SecurityDocumentTypeSelected(securityDocumentType) {

   if (securityDocumentType == 0) {
      closeForm();
      return;
   }

   switch (parseInt(securityDocumentType)) {

      case 1:
         $('.puWinTitle').html('Добавить патент');
         $('.puWinCont').html($("#addPatentCont").html());
         break;
      case 2:
         $('.puWinTitle').html('Добавить док. на авторское право');
         $('.puWinCont').html($("#addCopyrightCont").html());
         break;

   }

}

function DissertationDefenseTypeSelected(DissertationDefenseType) {

   if (DissertationDefenseType == 0) {
      closeForm();
      return;
   }

   $('.puWinTitle').html('Добавить инф. о защите диссертации.');
   $('.puWinCont').html($('.puCont#addDissertationDefenseCont').html());
   $("#DissertationDefenseType").val(DissertationDefenseType);
}

function AcademicDegreeTypeSelected(AcademicDegreeType) {

   if (AcademicDegreeType == 0) {
      closeForm();
      return;
   }

   $('.puWinTitle').html('Добавить инф. о получении научного звания.');
   $('.puWinCont').html($('.puCont#addAcademicDegreeCont').html());
   $("#AcademicDegreeType").val(AcademicDegreeType);
}



