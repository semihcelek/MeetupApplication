CREATE database meetupdb;

Use meetupdb;

create table users
(
    id           int unsigned primary key AUTO_INCREMENT,
    name         char(80)           not null,
    surname      char(80)           null,
    email        char(120)          not null unique,
    passwordHash char(255)          not null,
    isActive     bool default true  not null,
    isAdmin      bool default false not null
);

create table meetups
(
    id          int unsigned primary key AUTO_INCREMENT,
    name        char(80)  not null,
    description char(255) null,
    subject     char(120) not null unique,
    createdAt   timestamp not null,
    updatedAt   timestamp null
);

create table meetupMembership
(
    user   int unsigned not null,
    meetup int unsigned not null,
    primary key (user, meetup),
    constraint meetupMembership_users_fk foreign key users_fk (user) references users (id),
    constraint meetupMembership_meetups_fk foreign key meetups_fk (meetup) references meetups (id)
);

create table posts
(
    id         int unsigned primary key auto_increment,
    title      char(60)     not null unique,
    content    text         not null,
    author     int unsigned not null,
    meetupPost int unsigned null,
    createdAt  timestamp    not null,
    updatedAt  timestamp    null,
    constraint author_fk foreign key users_fk (author) references users (id),
    constraint meetupPost_fk foreign key meetup_fk (meetupPost) references meetups (id)

);

insert into users(name, surname, email, passwordHash, isActive, isAdmin)
values ('Enes', 'Sucuk', 'enes@mail.com', 'secretpassword', true, false);

insert into users(name, surname, email, passwordHash, isActive, isAdmin)
values ('Ege', 'Eroglu', 'mail@mail.com', 'secretpassword', true, false);

insert into meetups(name, description, subject, createdAt)
values ('Game Jam', 'We make games', 'Game Development', NOW());

insert into meetups(name, description, subject, createdAt)
values ('Guitar Workshop', 'We teach guitar', 'Music', NOW());


drop table users;

select *
from users;
select *
from meetups;