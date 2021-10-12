﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Username", "Website" },
                values: new object[,]
                {
                    { 1, "Leanne Graham", "Qrqtt3vATL0m", "Bret", "hildegard.org" },
                    { 2, "Ervin Howell", "eHCNa0kis30J", "Antonette", "anastasia.net" },
                    { 3, "Clementine Bauch", "W0jytwzOgoM6", "Samantha", "ramiro.info" },
                    { 4, "Patricia Lebsack", "qpoZ6jsUaROK", "Karianne", "kale.biz" },
                    { 5, "Chelsey Dietrich", "nBxPyd64wC3H", "Kamren", "demarco.info" },
                    { 6, "Mrs. Dennis Schulist", "ahTKyL1kBibn", "Leopoldo_Corkery", "ola.org" },
                    { 7, "Kurtis Weissnat", "Mlr9ezVTQUKl", "Elwyn.Skiles", "elvis.io" },
                    { 8, "Nicholas Runolfsdottir V", "LQ8bs4y4yQDZ", "Maxime_Nienow", "jacynthe.com" },
                    { 9, "Glenna Reichert", "PdZJLeVPSWZm", "Delphine", "conrad.com" },
                    { 10, "Clementina DuBuque", "hgsQizJszlGK", "Moriah.Stanton", "ambrose.net" },
                    { 11, "Admin Admin", "Admin123.", "Admin", "admin.ba" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto", "sunt aut facere repellat provident occaecati excepturi optio reprehenderit", 1 },
                    { 73, "voluptatem cumque tenetur consequatur expedita ipsum nemo quia explicabo\naut eum minima consequatur\ntempore cumque quae est et\net in consequuntur voluptatem voluptates aut", "consequuntur deleniti eos quia temporibus ab aliquid at", 8 },
                    { 72, "quam occaecati qui deleniti consectetur\nconsequatur aut facere quas exercitationem aliquam hic voluptas\nneque id sunt ut aut accusamus\nsunt consectetur expedita inventore velit", "sint hic doloribus consequatur eos non id", 8 },
                    { 71, "occaecati a doloribus\niste saepe consectetur placeat eum voluptate dolorem et\nqui quo quia voluptas\nrerum ut id enim velit est perferendis", "et iusto veniam et illum aut fuga", 8 },
                    { 70, "sunt repellendus quae\nest asperiores aut deleniti esse accusamus repellendus quia aut\nquia dolorem unde\neum tempora esse dolore", "voluptatem laborum magni", 7 },
                    { 69, "officiis error culpa consequatur modi asperiores et\ndolorum assumenda voluptas et vel qui aut vel rerum\nvoluptatum quisquam perspiciatis quia rerum consequatur totam quas\nsequi commodi repudiandae asperiores et saepe a", "fugiat quod pariatur odit minima", 7 },
                    { 68, "magnam molestiae perferendis quisquam\nqui cum reiciendis\nquaerat animi amet hic inventore\nea quia deleniti quidem saepe porro velit", "odio quis facere architecto reiciendis optio", 7 },
                    { 67, "reprehenderit id nostrum\nvoluptas doloremque pariatur sint et accusantium quia quod aspernatur\net fugiat amet\nnon sapiente et consequatur necessitatibus molestiae", "aliquid eos sed fuga est maxime repellendus", 7 },
                    { 66, "officia veritatis tenetur vero qui itaque\nsint non ratione\nsed et ut asperiores iusto eos molestiae nostrum\nveritatis quibusdam et nemo iusto saepe", "repudiandae ea animi iusto", 7 },
                    { 65, "voluptatibus ex esse\nsint explicabo est aliquid cumque adipisci fuga repellat labore\nmolestiae corrupti ex saepe at asperiores et perferendis\nnatus id esse incidunt pariatur", "consequatur id enim sunt et et", 7 },
                    { 64, "id velit blanditiis\neum ea voluptatem\nmolestiae sint occaecati est eos perspiciatis\nincidunt a error provident eaque aut aut qui", "et fugit quas eum in in aperiam quod", 7 },
                    { 63, "enim adipisci aspernatur nemo\nnumquam omnis facere dolorem dolor ex quis temporibus incidunt\nab delectus culpa quo reprehenderit blanditiis asperiores\naccusantium ut quam in voluptatibus voluptas ipsam dicta", "voluptas blanditiis repellendus animi ducimus error sapiente et suscipit", 7 },
                    { 62, "enim aspernatur illo distinctio quae praesentium\nbeatae alias amet delectus qui voluptate distinctio\nodit sint accusantium autem omnis\nquo molestiae omnis ea eveniet optio", "beatae enim quia vel", 7 },
                    { 61, "ab nemo optio odio\ndelectus tenetur corporis similique nobis repellendus rerum omnis facilis\nvero blanditiis debitis in nesciunt doloribus dicta dolores\nmagnam minus velit", "voluptatem doloribus consectetur est ut ducimus", 7 },
                    { 60, "asperiores sunt ab assumenda cumque modi velit\nqui esse omnis\nvoluptate et fuga perferendis voluptas\nillo ratione amet aut et omnis", "consequatur placeat omnis quisquam quia reprehenderit fugit veritatis facere", 6 },
                    { 59, "perspiciatis et quam ea autem temporibus non voluptatibus qui\nbeatae a earum officia nesciunt dolores suscipit voluptas et\nanimi doloribus cum rerum quas et magni\net hic ut ut commodi expedita sunt", "qui commodi dolor at maiores et quis id accusantium", 6 },
                    { 58, "veniam voluptatum quae adipisci id\net id quia eos ad et dolorem\naliquam quo nisi sunt eos impedit error\nad similique veniam", "voluptatum itaque dolores nisi et quasi", 6 },
                    { 57, "at pariatur consequuntur earum quidem\nquo est laudantium soluta voluptatem\nqui ullam et est\net cum voluptas voluptatum repellat est", "sed ab est est", 6 },
                    { 56, "aut est omnis dolores\nneque rerum quod ea rerum velit pariatur beatae excepturi\net provident voluptas corrupti\ncorporis harum reprehenderit dolores eligendi", "qui et at rerum necessitatibus", 6 },
                    { 55, "debitis excepturi ea perferendis harum libero optio\neos accusamus cum fuga ut sapiente repudiandae\net ut incidunt omnis molestiae\nnihil ut eum odit", "sit vel voluptatem et non libero", 6 },
                    { 54, "totam corporis dignissimos\nvitae dolorem ut occaecati accusamus\nex velit deserunt\net exercitationem vero incidunt corrupti mollitia", "sit asperiores ipsam eveniet odio non quia", 6 },
                    { 53, "minima harum praesentium eum rerum illo dolore\nquasi exercitationem rerum nam\nporro quis neque quo\nconsequatur minus dolor quidem veritatis sunt non explicabo similique", "ut quo aut ducimus alias", 6 },
                    { 74, "odit qui et et necessitatibus sint veniam\nmollitia amet doloremque molestiae commodi similique magnam et quam\nblanditiis est itaque\nquo et tenetur ratione occaecati molestiae tempora", "enim unde ratione doloribus quas enim ut sit sapiente", 8 },
                    { 52, "iusto est quibusdam fuga quas quaerat molestias\na enim ut sit accusamus enim\ntemporibus iusto accusantium provident architecto\nsoluta esse reprehenderit qui laborum", "qui enim et consequuntur quia animi quis voluptate quibusdam", 6 },
                    { 75, "commodi non non omnis et voluptas sit\nautem aut nobis magnam et sapiente voluptatem\net laborum repellat qui delectus facilis temporibus\nrerum amet et nemo voluptate expedita adipisci error dolorem", "dignissimos eum dolor ut enim et delectus in", 8 },
                    { 77, "modi ut in nulla repudiandae dolorum nostrum eos\naut consequatur omnis\nut incidunt est omnis iste et quam\nvoluptates sapiente aliquam asperiores nobis amet corrupti repudiandae provident", "necessitatibus quasi exercitationem odio", 8 },
                    { 98, "doloremque ex facilis sit sint culpa\nsoluta assumenda eligendi non ut eius\nsequi ducimus vel quasi\nveritatis est dolores", "laboriosam dolor voluptates", 10 },
                    { 97, "eum non blanditiis soluta porro quibusdam voluptas\nvel voluptatem qui placeat dolores qui velit aut\nvel inventore aut cumque culpa explicabo aliquid at\nperspiciatis est et voluptatem dignissimos dolor itaque sit nam", "quas fugiat ut perspiciatis vero provident", 10 },
                    { 96, "in non odio excepturi sint eum\nlabore voluptates vitae quia qui et\ninventore itaque rerum\nveniam non exercitationem delectus aut", "quaerat velit veniam amet cupiditate aut numquam ut sequi", 10 },
                    { 95, "earum voluptatem facere provident blanditiis velit laboriosam\npariatur accusamus odio saepe\ncumque dolor qui a dicta ab doloribus consequatur omnis\ncorporis cupiditate eaque assumenda ad nesciunt", "id minus libero illum nam ad officiis", 10 },
                    { 94, "aspernatur expedita soluta quo ab ut similique\nexpedita dolores amet\nsed temporibus distinctio magnam saepe deleniti\nomnis facilis nam ipsum natus sint similique omnis", "qui qui voluptates illo iste minima", 10 },
                    { 93, "dolorem quibusdam ducimus consequuntur dicta aut quo laboriosam\nvoluptatem quis enim recusandae ut sed sunt\nnostrum est odit totam\nsit error sed sunt eveniet provident qui nulla", "beatae soluta recusandae", 10 },
                    { 92, "aut et excepturi dicta laudantium sint rerum nihil\nlaudantium et at\na neque minima officia et similique libero et\ncommodi voluptate qui", "ratione ex tenetur perferendis", 10 },
                    { 91, "libero voluptate eveniet aperiam sed\nsunt placeat suscipit molestias\nsimilique fugit nam natus\nexpedita consequatur consequatur dolores quia eos et placeat", "aut amet sed", 10 },
                    { 90, "minus omnis soluta quia\nqui sed adipisci voluptates illum ipsam voluptatem\neligendi officia ut in\neos soluta similique molestias praesentium blanditiis", "ad iusto omnis odit dolor voluptatibus", 9 },
                    { 89, "repellat aut aperiam totam temporibus autem et\narchitecto magnam ut\nconsequatur qui cupiditate rerum quia soluta dignissimos nihil iure\ntempore quas est", "sint soluta et vel magnam aut ut sed qui", 9 },
                    { 88, "consequatur omnis est praesentium\nducimus non iste\nneque hic deserunt\nvoluptatibus veniam cum et rerum sed", "sapiente omnis fugit eos", 9 },
                    { 87, "eos et molestiae\nnesciunt ut a\ndolores perspiciatis repellendus repellat aliquid\nmagnam sint rem ipsum est", "nostrum quis quasi placeat", 9 },
                    { 86, "quasi excepturi consequatur iste autem temporibus sed molestiae beatae\net quaerat et esse ut\nvoluptatem occaecati et vel explicabo autem\nasperiores pariatur deserunt optio", "placeat quia et porro iste", 9 },
                    { 85, "similique sed nisi voluptas iusto omnis\nmollitia et quo\nassumenda suscipit officia magnam sint sed tempora\nenim provident pariatur praesentium atque animi amet ratione", "dolore veritatis porro provident adipisci blanditiis et sunt", 9 },
                    { 84, "sint molestiae magni a et quos\neaque et quasi\nut rerum debitis similique veniam\nrecusandae dignissimos dolor incidunt consequatur odio", "optio ipsam molestias necessitatibus occaecati facilis veritatis dolores aut", 9 },
                    { 83, "est molestiae facilis quis tempora numquam nihil qui\nvoluptate sapiente consequatur est qui\nnecessitatibus autem aut ipsa aperiam modi dolore numquam\nreprehenderit eius rem quibusdam", "odit et voluptates doloribus alias odio et", 9 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title", "UserId" },
                values: new object[,]
                {
                    { 82, "ut libero sit aut totam inventore sunt\nporro sint qui sunt molestiae\nconsequatur cupiditate qui iste ducimus adipisci\ndolor enim assumenda soluta laboriosam amet iste delectus hic", "laudantium voluptate suscipit sunt enim enim", 9 },
                    { 81, "facere qui nesciunt est voluptatum voluptatem nisi\nsequi eligendi necessitatibus ea at rerum itaque\nharum non ratione velit laboriosam quis consequuntur\nex officiis minima doloremque voluptas ut aut", "tempora rem veritatis voluptas quo dolores vero", 9 },
                    { 80, "ex quod dolorem ea eum iure qui provident amet\nquia qui facere excepturi et repudiandae\nasperiores molestias provident\nminus incidunt vero fugit rerum sint sunt excepturi provident", "labore in ex et explicabo corporis aut quas", 8 },
                    { 79, "libero accusantium et et facere incidunt sit dolorem\nnon excepturi qui quia sed laudantium\nquisquam molestiae ducimus est\nofficiis esse molestiae iste et quos", "pariatur consequatur quia magnam autem omnis non amet", 8 },
                    { 78, "nobis facilis odit tempore cupiditate quia\nassumenda doloribus rerum qui ea\nillum et qui totam\naut veniam repellendus", "quam voluptatibus rerum veritatis", 8 },
                    { 76, "ut animi facere\ntotam iusto tempore\nmolestiae eum aut et dolorem aperiam\nquaerat recusandae totam odio", "doloremque officiis ad et non perferendis", 8 },
                    { 51, "sunt dolores aut doloribus\ndolore doloribus voluptates tempora et\ndoloremque et quo\ncum asperiores sit consectetur dolorem", "soluta aliquam aperiam consequatur illo quis voluptas", 6 },
                    { 50, "error suscipit maxime adipisci consequuntur recusandae\nvoluptas eligendi et est et voluptates\nquia distinctio ab amet quaerat molestiae et vitae\nadipisci impedit sequi nesciunt quis consectetur", "repellendus qui recusandae incidunt voluptates tenetur qui omnis exercitationem", 5 },
                    { 49, "inventore ab sint\nnatus fugit id nulla sequi architecto nihil quaerat\neos tenetur in in eum veritatis non\nquibusdam officiis aspernatur cumque aut commodi aut", "laborum non sunt aut ut assumenda perspiciatis voluptas", 5 },
                    { 22, "eos qui et ipsum ipsam suscipit aut\nsed omnis non odio\nexpedita earum mollitia molestiae aut atque rem suscipit\nnam impedit esse", "dolor sint quo a velit explicabo quia nam", 3 },
                    { 21, "repellat aliquid praesentium dolorem quo\nsed totam minus non itaque\nnihil labore molestiae sunt dolor eveniet hic recusandae veniam\ntempora et tenetur expedita sunt", "asperiores ea ipsam voluptatibus modi minima quia sint", 3 },
                    { 20, "qui consequuntur ducimus possimus quisquam amet similique\nsuscipit porro ipsam amet\neos veritatis officiis exercitationem vel fugit aut necessitatibus totam\nomnis rerum consequatur expedita quidem cumque explicabo", "doloribus ad provident suscipit at", 2 },
                    { 19, "illum quis cupiditate provident sit magnam\nea sed aut omnis\nveniam maiores ullam consequatur atque\nadipisci quo iste expedita sit quos voluptas", "adipisci placeat illum aut reiciendis qui", 2 },
                    { 18, "eveniet quo quis\nlaborum totam consequatur non dolor\nut et est repudiandae\nest voluptatem vel debitis et magnam", "voluptate et itaque vero tempora molestiae", 2 },
                    { 17, "eos voluptas et aut odit natus earum\naspernatur fuga molestiae ullam\ndeserunt ratione qui eos\nqui nihil ratione nemo velit ut aut id quo", "fugit voluptas sed molestias voluptatem provident", 2 },
                    { 16, "suscipit nam nisi quo aperiam aut\nasperiores eos fugit maiores voluptatibus quia\nvoluptatem quis ullam qui in alias quia est\nconsequatur magni mollitia accusamus ea nisi voluptate dicta", "sint suscipit perspiciatis velit dolorum rerum ipsa laboriosam odio", 2 },
                    { 15, "reprehenderit quos placeat\nvelit minima officia dolores impedit repudiandae molestiae nam\nvoluptas recusandae quis delectus\nofficiis harum fugiat vitae", "eveniet quod temporibus", 2 },
                    { 14, "fuga et accusamus dolorum perferendis illo voluptas\nnon doloremque neque facere\nad qui dolorum molestiae beatae\nsed aut voluptas totam sit illum", "voluptatem eligendi optio", 2 },
                    { 13, "aut dicta possimus sint mollitia voluptas commodi quo doloremque\niste corrupti reiciendis voluptatem eius rerum\nsit cumque quod eligendi laborum minima\nperferendis recusandae assumenda consectetur porro architecto ipsum ipsam", "dolorum ut in voluptas mollitia et saepe quo animi", 2 },
                    { 12, "itaque id aut magnam\npraesentium quia et ea odit et ea voluptas et\nsapiente quia nihil amet occaecati quia id voluptatem\nincidunt ea est distinctio odio", "in quibusdam tempore odit est dolorem", 2 },
                    { 11, "delectus reiciendis molestiae occaecati non minima eveniet qui voluptatibus\naccusamus in eum beatae sit\nvel qui neque voluptates ut commodi qui incidunt\nut animi commodi", "et ea vero quia laudantium autem", 2 },
                    { 10, "quo et expedita modi cum officia vel magni\ndoloribus qui repudiandae\nvero nisi sit\nquos veniam quod sed accusamus veritatis error", "optio molestias id quia eum", 1 },
                    { 9, "consectetur animi nesciunt iure dolore\nenim quia ad\nveniam autem ut quam aut nobis\net est aut quod aut provident voluptas autem voluptas", "nesciunt iure omnis dolorem tempora et accusantium", 1 },
                    { 8, "dignissimos aperiam dolorem qui eum\nfacilis quibusdam animi sint suscipit qui sint possimus cum\nquaerat magni maiores excepturi\nipsam ut commodi dolor voluptatum modi aut vitae", "dolorem dolore est ipsam", 1 },
                    { 7, "dolore placeat quibusdam ea quo vitae\nmagni quis enim qui quis quo nemo aut saepe\nquidem repellat excepturi ut quia\nsunt ut sequi eos ea sed quas", "magnam facilis autem", 1 },
                    { 6, "ut aspernatur corporis harum nihil quis provident sequi\nmollitia nobis aliquid molestiae\nperspiciatis et ea nemo ab reprehenderit accusantium quas\nvoluptate dolores velit et doloremque molestiae", "dolorem eum magni eos aperiam quia", 1 },
                    { 5, "repudiandae veniam quaerat sunt sed\nalias aut fugiat sit autem sed est\nvoluptatem omnis possimus esse voluptatibus quis\nest aut tenetur dolor neque", "nesciunt quas odio", 1 },
                    { 4, "ullam et saepe reiciendis voluptatem adipisci\nsit amet autem assumenda provident rerum culpa\nquis hic commodi nesciunt rem tenetur doloremque ipsam iure\nquis sunt voluptatem rerum illo velit", "eum et est occaecati", 1 },
                    { 3, "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut", "ea molestias quasi exercitationem repellat qui ipsa sit aut", 1 },
                    { 2, "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla", "qui est esse", 1 },
                    { 23, "veritatis unde neque eligendi\nquae quod architecto quo neque vitae\nest illo sit tempora doloremque fugit quod\net et vel beatae sequi ullam sed tenetur perspiciatis", "maxime id vitae nihil numquam", 3 },
                    { 24, "enim et ex nulla\nomnis voluptas quia qui\nvoluptatem consequatur numquam aliquam sunt\ntotam recusandae id dignissimos aut sed asperiores deserunt", "autem hic labore sunt dolores incidunt", 3 },
                    { 25, "ullam consequatur ut\nomnis quis sit vel consequuntur\nipsa eligendi ipsum molestiae et omnis error nostrum\nmolestiae illo tempore quia et distinctio", "rem alias distinctio quo quis", 3 },
                    { 26, "similique esse doloribus nihil accusamus\nomnis dolorem fuga consequuntur reprehenderit fugit recusandae temporibus\nperspiciatis cum ut laudantium\nomnis aut molestiae vel vero", "est et quae odit qui non", 3 },
                    { 48, "voluptates quo voluptatem facilis iure occaecati\nvel assumenda rerum officia et\nillum perspiciatis ab deleniti\nlaudantium repellat ad ut et autem reprehenderit", "ut voluptatem illum ea doloribus itaque eos", 5 },
                    { 47, "voluptatem assumenda ut qui ut cupiditate aut impedit veniam\noccaecati nemo illum voluptatem laudantium\nmolestiae beatae rerum ea iure soluta nostrum\neligendi et voluptate", "quibusdam cumque rem aut deserunt", 5 },
                    { 46, "voluptatem quisquam iste\nvoluptatibus natus officiis facilis dolorem\nquis quas ipsam\nvel et voluptatum in aliquid", "aut quo modi neque nostrum ducimus", 5 },
                    { 45, "est natus reiciendis nihil possimus aut provident\nex et dolor\nrepellat pariatur est\nnobis rerum repellendus dolorem autem", "ut numquam possimus omnis eius suscipit laudantium iure", 5 },
                    { 44, "temporibus est consectetur dolore\net libero debitis vel velit laboriosam quia\nipsum quibusdam qui itaque fuga rem aut\nea et iure quam sed maxime ut distinctio quae", "optio dolor molestias sit", 5 },
                    { 43, "similique fugit est\nillum et dolorum harum et voluptate eaque quidem\nexercitationem quos nam commodi possimus cum odio nihil nulla\ndolorum exercitationem magnam ex et a et distinctio debitis", "eligendi iste nostrum consequuntur adipisci praesentium sit beatae perferendis", 5 },
                    { 42, "odio fugit voluptatum ducimus earum autem est incidunt voluptatem\nodit reiciendis aliquam sunt sequi nulla dolorem\nnon facere repellendus voluptates quia\nratione harum vitae ut", "commodi ullam sint et excepturi error explicabo praesentium voluptas", 5 },
                    { 41, "molestias id nostrum\nexcepturi molestiae dolore omnis repellendus quaerat saepe\nconsectetur iste quaerat tenetur asperiores accusamus ex ut\nnam quidem est ducimus sunt debitis saepe", "non est facere", 5 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title", "UserId" },
                values: new object[,]
                {
                    { 40, "ut voluptatum aliquid illo tenetur nemo sequi quo facilis\nipsum rem optio mollitia quas\nvoluptatem eum voluptas qui\nunde omnis voluptatem iure quasi maxime voluptas nam", "enim quo cumque", 4 },
                    { 39, "corporis rerum ducimus vel eum accusantium\nmaxime aspernatur a porro possimus iste omnis\nest in deleniti asperiores fuga aut\nvoluptas sapiente vel dolore minus voluptatem incidunt ex", "eos dolorem iste accusantium est eaque quam", 4 },
                    { 99, "quo deleniti praesentium dicta non quod\naut est molestias\nmolestias et officia quis nihil\nitaque dolorem quia", "temporibus sit alias delectus eligendi possimus magni", 10 },
                    { 38, "animi esse sit aut sit nesciunt assumenda eum voluptas\nquia voluptatibus provident quia necessitatibus ea\nrerum repudiandae quia voluptatem delectus fugit aut id quia\nratione optio eos iusto veniam iure", "explicabo et eos deleniti nostrum ab id repellendus", 4 },
                    { 36, "ad mollitia et omnis minus architecto odit\nvoluptas doloremque maxime aut non ipsa qui alias veniam\nblanditiis culpa aut quia nihil cumque facere et occaecati\nqui aspernatur quia eaque ut aperiam inventore", "fuga nam accusamus voluptas reiciendis itaque", 4 },
                    { 35, "nisi error delectus possimus ut eligendi vitae\nplaceat eos harum cupiditate facilis reprehenderit voluptatem beatae\nmodi ducimus quo illum voluptas eligendi\net nobis quia fugit", "id nihil consequatur molestias animi provident", 4 },
                    { 34, "ea velit perferendis earum ut voluptatem voluptate itaque iusto\ntotam pariatur in\nnemo voluptatem voluptatem autem magni tempora minima in\nest distinctio qui assumenda accusamus dignissimos officia nesciunt nobis", "magnam ut rerum iure", 4 },
                    { 33, "rerum ut et numquam laborum odit est sit\nid qui sint in\nquasi tenetur tempore aperiam et quaerat qui in\nrerum officiis sequi cumque quod", "qui explicabo molestiae dolorem", 4 },
                    { 32, "deserunt eos nobis asperiores et hic\nest debitis repellat molestiae optio\nnihil ratione ut eos beatae quibusdam distinctio maiores\nearum voluptates et aut adipisci ea maiores voluptas maxime", "doloremque illum aliquid sunt", 4 },
                    { 31, "debitis eius sed quibusdam non quis consectetur vitae\nimpedit ut qui consequatur sed aut in\nquidem sit nostrum et maiores adipisci atque\nquaerat voluptatem adipisci repudiandae", "ullam ut quidem id aut vel consequuntur", 4 },
                    { 30, "alias dolor cumque\nimpedit blanditiis non eveniet odio maxime\nblanditiis amet eius quis tempora quia autem rem\na provident perspiciatis quia", "a quo magni similique perferendis", 3 },
                    { 29, "odit magnam ut saepe sed non qui\ntempora atque nihil\naccusamus illum doloribus illo dolor\neligendi repudiandae odit magni similique sed cum maiores", "iusto eius quod necessitatibus culpa ea", 3 },
                    { 28, "non et quaerat ex quae ad maiores\nmaiores recusandae totam aut blanditiis mollitia quas illo\nut voluptatibus voluptatem\nsimilique nostrum eum", "delectus ullam et corporis nulla voluptas sequi", 3 },
                    { 27, "eum sed dolores ipsam sint possimus debitis occaecati\ndebitis qui qui et\nut placeat enim earum aut odit facilis\nconsequatur suscipit necessitatibus rerum sed inventore temporibus consequatur", "quasi id et eos tenetur aut quo autem", 3 },
                    { 37, "debitis et eaque non officia sed nesciunt pariatur vel\nvoluptatem iste vero et ea\nnumquam aut expedita ipsum nulla in\nvoluptates omnis consequatur aut enim officiis in quam qui", "provident vel ut sit ratione est", 4 },
                    { 100, "cupiditate quo est a modi nesciunt soluta\nipsa voluptas error itaque dicta in\nautem qui minus magnam et distinctio eum\naccusamus ratione error aut", "at nam consequatur ea labore ea harum", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
