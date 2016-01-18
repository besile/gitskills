<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="h_list.aspx.vb" Inherits="Humor_h_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div class="container-fluid">
        <!-- BEGIN PAGE CONTENT-->
        <div class="row-fluid">
            <div class="span4">
                <div>
                    <a class="btn red dn" id="delete" href="javascript:;"><i class="icon-trash icon-white">
                    </i>删除</a> <a class="btn blue thickbox" title="添加新用户" href="http://guozili.28.web1268.net/Account/User/Create?TB_iframe=true&amp;height=350&amp;width=500">
                        <i class="icon-plus icon-white"></i>新增</a>
                </div>
            </div>
            <div class="span8">
                <form action="./用户管理 - GMS管理系统_files/用户管理 - GMS管理系统.html" id="search" method="get">
                <div class="dataTables_filter">
                    <label>
                        <button type="submit" class="btn">
                            搜索 <i class="icon-search"></i>
                        </button>
                    </label>
                    <label>
                        <span>帖子标题：</span>
                        <input class="m-wrap small" id="humorTitle" name="humorTitle" type="text" value="" />
                    </label>
                    <label>
                        <span>用户名：</span>
                        <input class="m-wrap small" id="createName" name="createName" type="text" value="" />
                    </label>
                    <label>
                        <span>是否删除：</span>
                        <input class="m-wrap small" id="Text1" name="createName" type="text" value="" />
                    </label>
                </div>
                </form>
            </div>
        </div>
        <div class="alert">
            <button class="close" data-dismiss="alert">
            </button>
            <strong>用户权限相关：</strong> 请编辑其所属角色的权限，用户的权限是其所有角色所拥有的权限汇总！
        </div>
        <form action="http://guozili.28.web1268.net/Account/User/Delete" id="mainForm" method="post">
        <table class="table table-striped table-hover ">
            <thead>
                <tr>
                    <th style="width: 8px;">
                        <div class="checker" id="uniform-checkall">
                            <span>
                                <div class="checker" id="uniform-checkall">
                                    <span>
                                        <input type="checkbox" id="checkall" class="group-checkable" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </th>
                    <th>
                        登录名
                    </th>
                    <th>
                        邮箱
                    </th>
                    <th>
                        电话
                    </th>
                    <th class="hidden-480">
                        角色
                    </th>
                    <th>
                        激活
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="23" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        jun
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="hidden-480">
                        jun
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/23?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="22" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        a
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="hidden-480">
                        系统管理员,超级管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/22?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="21" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        hl
                    </td>
                    <td>
                        hli@126.com
                    </td>
                    <td>
                        13914567654
                    </td>
                    <td class="hidden-480">
                        系统管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/21?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="20" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        123412
                    </td>
                    <td>
                        111@11.cn
                    </td>
                    <td>
                        13511111234
                    </td>
                    <td class="hidden-480">
                        系统管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/20?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="19" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        ttttt
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="hidden-480">
                        系统管理员,超级管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/19?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="18" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        test11
                    </td>
                    <td>
                        test@live.cn
                    </td>
                    <td>
                        13245569874
                    </td>
                    <td class="hidden-480">
                        系统管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/18?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="17" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        张三
                    </td>
                    <td>
                        ii@tom.com
                    </td>
                    <td>
                    </td>
                    <td class="hidden-480">
                        系统管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/17?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="16" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        ces
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="hidden-480">
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/16?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="15" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        win
                    </td>
                    <td>
                        asdf@126.com
                    </td>
                    <td>
                    </td>
                    <td class="hidden-480">
                        系统管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/15?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="14" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        zhangsan
                    </td>
                    <td>
                        416456@163.com
                    </td>
                    <td>
                        15811147854
                    </td>
                    <td class="hidden-480">
                        系统管理员
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/14?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="13" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        111111
                    </td>
                    <td>
                        guozili@163.com
                    </td>
                    <td>
                        13911153443
                    </td>
                    <td class="hidden-480">
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/13?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="checker" id="uniform-undefined">
                            <span>
                                <div class="checker" id="uniform-undefined">
                                    <span>
                                        <input type="checkbox" class="checkboxes" name="ids" value="12" style="opacity: 0;"></span></div>
                            </span>
                        </div>
                    </td>
                    <td>
                        qc
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td class="hidden-480">
                    </td>
                    <td>
                        <span class="label label-success">True</span>
                    </td>
                    <td>
                        <a class="btn mini purple thickbox" title="编辑用户资料" href="http://guozili.28.web1268.net/Account/User/Edit/12?TB_iframe=true&amp;height=350&amp;width=500">
                            <i class="icon-edit"></i>编辑 </a>
                    </td>
                </tr>
            </tbody>
        </table>
        </form>
        <div class="dataTables_paginate paging_bootstrap pagination">
            <!--MvcPager 1.5 for ASP.NET MVC 3.0 © 2009-2011 Webdiyer (http://www.webdiyer.com)-->
            <div class="pages">
                <a disabled="disabled">首页</a>&nbsp;&nbsp;<a disabled="disabled">上一页</a>&nbsp;&nbsp;1&nbsp;&nbsp;<a
                    href="http://guozili.28.web1268.net/Account/User/Index?pageIndex=2">2</a>&nbsp;&nbsp;<a
                        href="http://guozili.28.web1268.net/Account/User/Index?pageIndex=2">下一页</a>&nbsp;&nbsp;<a
                            href="http://guozili.28.web1268.net/Account/User/Index?pageIndex=2">尾页</a><span>总条数:
                                20</span></div>
            <!--MvcPager 1.5 for ASP.NET MVC 3.0 © 2009-2011 Webdiyer (http://www.webdiyer.com)-->
        </div>
        <!-- END PAGE CONTENT-->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="Server">
</asp:Content>
