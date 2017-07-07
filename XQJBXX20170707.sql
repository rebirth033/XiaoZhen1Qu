-- Create table
create table XQJBXX
(
  xqjbxxid  INTEGER not null,
  xqmc      VARCHAR2(100),
  xqdz      VARCHAR2(200),
  xqmcpy    VARCHAR2(300),
  xqmcpyqkg VARCHAR2(300),
  xqmcpyszm VARCHAR2(100)
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
-- Add comments to the columns 
comment on column XQJBXX.xqjbxxid
  is 'ID';
comment on column XQJBXX.xqmc
  is 'С������';
comment on column XQJBXX.xqdz
  is 'С����ַ';
comment on column XQJBXX.xqmcpy
  is 'С������ƴ��';
comment on column XQJBXX.xqmcpyqkg
  is 'С������ƴ��ȥ�ո�';
comment on column XQJBXX.xqmcpyszm
  is 'С������ƴ������ĸ';
-- Create/Recreate primary, unique and foreign key constraints 
alter table XQJBXX
  add primary key (XQJBXXID)
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
