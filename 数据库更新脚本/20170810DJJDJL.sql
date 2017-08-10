-- Create table
create table DJJDJL
(
  djjdjlid VARCHAR2(50) not null,
  cjsj     DATE,
  je       NUMBER(10,2),
  lx       VARCHAR2(10),
  bz       VARCHAR2(100),
  yhzhxxid VARCHAR2(50)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table DJJDJL
  is '�û��˻�_����ⶳ��¼';
-- Add comments to the columns 
comment on column DJJDJL.djjdjlid
  is '����';
comment on column DJJDJL.cjsj
  is '����ʱ��';
comment on column DJJDJL.je
  is '���';
comment on column DJJDJL.lx
  is '����';
comment on column DJJDJL.bz
  is '��ע';
comment on column DJJDJL.yhzhxxid
  is '�û��˻�ID';
-- Create/Recreate primary, unique and foreign key constraints 
alter table DJJDJL
  add primary key (DJJDJLID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
