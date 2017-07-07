-- Create table
create table XQJBXX
(
  xqjbxxid INTEGER not null,
  xqmc     VARCHAR2(100),
  xqdz     VARCHAR2(200)
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
  is '小区名称';
comment on column XQJBXX.xqdz
  is '小区地址';
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
