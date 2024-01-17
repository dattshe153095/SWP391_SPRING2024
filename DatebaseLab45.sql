create database [Web_Trung_Gian]

create table account_roles(
id int primary key,
role nvarchar(50),
is_delete bit default 0
)


create table account(
id int identity(1,1) primary key,
name nvarchar(100),
avatar varchar(500),
username varchar(50),
email varchar(500),
password varchar(200),
description nvarchar(500),
created_at DATETIME DEFAULT GETDATE(),
updated_at DATETIME DEFAULT GETDATE(),
is_delete bit default 0, -- 0: chưa xóa, 1: đã xóa
id_role int default 2,
foreign key (id_role) references account_roles(id)
)

go 
CREATE TRIGGER update_timestamp
ON account
AFTER UPDATE
AS
BEGIN
    UPDATE account
    SET updated_at = GETDATE()
    FROM account
    INNER JOIN inserted ON account.id = inserted.id;
END;

-- Thêm FK:
--alter table Lop
--add constraint FK_MaKhoa foreign key (MaKhoa) references Khoa(MaKhoa)

-- insert role 
insert into account_roles
values(1,'admin',0),
(2,'user',0)


select * from account_roles
select * from account
insert into account(name,avatar,username,email,password,description,id_role)
values('chien nguyen','sdsadsadas','chien123','ngyds@gmial.com','123',N'tôi quê Nghệ An',2),
('hoang','fsdsdf','hoang213','fdssd@gmial.com','333',N'tôi 20 tuổi cần tìm mối',2),
('hung','ffdsffsd','hungday','123@gmial.com','543',N'hello',2),
('admin1','fdafsdfd','admin1','admin@gmail.com','admin','.',1)

update account set [name] = 'chien1' where id = 1





