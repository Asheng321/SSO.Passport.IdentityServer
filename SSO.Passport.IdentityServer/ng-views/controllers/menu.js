﻿myApp.controller("menu", ["$scope", "$http", "$timeout","$location", function($scope, $http, $timeout,$location) {
	window.hub.disconnect();
	$scope.loading();
	$scope.menu = {};
	$scope.appid="";
	$scope.query="";
	$scope.init = function() {
		$scope.request("/app/getall",null, function(data) {
			$scope.apps=data.Data;
			$scope.appid=$location.search()['appid']||$scope.apps[0].AppId;
			$('.ui.dropdown.apps').dropdown({
				onChange: function (value) {
					$scope.appid=value;
					$scope.request("/menu/GetAll", {
						appid:value
					}, function(data) {
						$scope.data = transData(data.Data, "Id", "ParentId", "nodes");
					});	
				},
				message: {
					maxSelections: '最多选择 {maxCount} 项',
					noResults: '无搜索结果！'
				}
			});
			$timeout(function() {
				$scope.appid=$location.search()['appid']||$scope.apps[0].AppId;
				$('.ui.dropdown.apps').dropdown("set selected", [$scope.appid]);
			},10);
		});
	}
	var sourceId, destId, index, parent, sourceIndex;
	$scope.treeOptions = {
		beforeDrop: function(e) {
			index = e.dest.index;
			if (e.dest.nodesScope.$parent.$modelValue) {
				parent = e.dest.nodesScope.$parent.$modelValue; //找出父级元素
				if ((parent.Url && parent.Url != "#")||(parent.Route && parent.Route != "#")||(parent.RouteName && parent.RouteName != "#")) {
					swal("异常操作！", "菜单【" + parent.Name + "】是一个有链接的菜单，不能作为父级菜单", "error");
					return false;
				}
			}
		},
		dropped: function(e) {
			var dest = e.dest.nodesScope;
			destId = dest.$id;
			var pid = dest.node ? dest.node.id : 0; //pid
			var prev = null;
			var next = null;
			if (index > sourceIndex) {
				next = dest.$modelValue[index + 1], prev = dest.$modelValue[index];
			} else if (index < sourceIndex) {
				next = dest.$modelValue[index], prev = dest.$modelValue[index - 1];
			} else {
				next = dest.$modelValue[index];
			}
			var current = e.source.nodeScope.$modelValue;
			if (destId == sourceId) {
				if (index == sourceIndex) {
					//位置没改变
					return;
				}
				//同级内改变位置，找出兄弟结点，排序号更新
				if (prev || next) {
					//有多个子节点
					if (next) {
						//console.log("自己：", current, "后一个元素：", next);
						current.ParentId = pid;
						current.Sort = next.Sort - 1;
						$scope.request("/menu/save", current, function(data) {
							window.notie.alert({
								type: 1,
								text: data.Message,
								time: 3
							});
						});
					} else if (prev) {
						//console.log("自己：", current, "前一个元素：", prev);
						current.ParentId = pid;
						current.Sort = prev.Sort + 1;
						$scope.request("/menu/save", current, function (data) {
							window.notie.alert({
								type: 1,
								text: data.Message,
								time: 3
							});
						});
					}
				}
			} else {
				//层级位置改变
				if (parent) {
					//非顶级元素
					//找兄弟结点
					next = dest.$modelValue[index], prev = dest.$modelValue[index - 1];
					if (prev || next) {
						//有多个子节点
						if (next) {
							//console.log("自己：", current, "后一个元素：", next);
							current.ParentId = parent.Id;
							current.Sort = next.Sort - 1;
							$scope.request("/menu/save", current, function (data) {
								window.notie.alert({
									type: 1,
									text: data.Message,
									time: 3
								});
							});
						} else if (prev) {
							//console.log("自己：", current, "前一个元素：", prev);
							current.ParentId = parent.Id;
							current.Sort = prev.Sort + 1;
							$scope.request("/menu/save", current, function (data) {
								window.notie.alert({
									type: 1,
									text: data.Message,
									time: 3
								});
							});
						}
					} else {
						//只有一个元素
						//console.log("自己：", current, "父亲元素：", parent);
						current.ParentId = parent.Id;
						current.Sort = parent.Sort * 10;
						$scope.request("/menu/save", current, function (data) {
							window.notie.alert({
								type: 1,
								text: data.Message,
								time: 3
							});
						});
					}
				} else {
					//顶级元素
					sourceIndex = e.source.nodesScope.$parent.index();
					if (index < sourceIndex) {
						next = dest.$modelValue[index + 1], prev = dest.$modelValue[index];
					} else {
						next = dest.$modelValue[index], prev = dest.$modelValue[index - 1];
					}
					//console.log("后一个元素：", next, "前一个元素：", prev, "自己：", current);
					if (next) {
						current.ParentId = pid;
						current.Sort = next.Sort - 1;
						$scope.request("/menu/save", current, function (data) {
							window.notie.alert({
								type: 1,
								text: data.Message,
								time: 3
							});
						});
					} else if (prev) {
						current.ParentId = pid;
						current.Sort = prev.Sort + 1;
						$scope.request("/menu/save", current, function (data) {
							window.notie.alert({
								type: 1,
								text: data.Message,
								time: 3
							});
						});
					}
				}
				parent = null;
			}
		},
		dragStart: function(e) {
			sourceId = e.dest.nodesScope.$id;
			sourceIndex = e.dest.index;
		}
	};
	$scope.findNodes = function () {
		$scope.request("/menu/GetAll", {
			appid:$scope.appid,
			kw:$scope.query
		}, function(data) {
			$scope.data = transData(data.Data, "Id", "ParentId", "nodes");
		});	
	};
	$scope.visible = function (item) {
		return true;//!($scope.query && $scope.query.length > 0 && item.Name.indexOf($scope.query) == -1);
	};
	$scope.menu = {};
	$scope.newItem = function() {
		layer.open({
			type: 1,
			zIndex: 20,
			title: '修改菜单信息',
			area: (window.screen.width > 600 ? 600 : window.screen.width) + 'px',// '340px'], //宽高
			content: $("#modal"),
			success: function(layero, index) {
				$scope.menu = {};
			},
			end: function() {
				$("#modal").css("display", "none");
			}
		});
		var nodeData = $scope.data[$scope.data.length - 1];
		$scope.menu.Sort = nodeData.Sort + (nodeData.nodes.length + 1) * 10;
		$scope.menu.ParentId  = 0;
	};
	$scope.submenu = {};

	$scope.closeAll = function() {
		layer.closeAll();
		setTimeout(function() {
			$("#modal").css("display", "none");
		}, 500);
	}
	$scope.newSubItem = function (scope) {
		layer.open({
			type: 1,
			zIndex: 20,
			title: '修改菜单信息',
			area: (window.screen.width > 600 ? 600 : window.screen.width) + 'px',// '340px'], //宽高
			content: $("#modal"),
			success: function(layero, index) {
				$scope.menu = {};
			},
			end: function() {
				$("#modal").css("display", "none");
			}
		});
		var nodeData = scope.$modelValue;
		$scope.submenu = nodeData;
		if (nodeData.Url && nodeData.Url != "#") {
			swal("异常操作！", "菜单【" + nodeData.Name + "】是一个有链接的菜单，不能作为父级菜单", "error");
			return false;
		}
		$scope.menu.Sort = (nodeData.Sort + nodeData.nodes.length + 1) * 10;
		$scope.menu.ParentId = nodeData.Id;
	};
	$scope.expandAll = function() {
		if ($scope.collapse) {
			$scope.$broadcast('angular-ui-tree:collapse-all');
		} else {
			$scope.$broadcast('angular-ui-tree:expand-all');
		}
		$scope.collapse = !$scope.collapse;
	};
	
	$scope.del = function(scope) {
		var model = scope.$nodeScope.$modelValue;
		var id = model.Id;
		swal({
			title: "确认删除这个菜单吗？",
			text: model.Name,
			showCancelButton: true,
			showCloseButton: true,
			confirmButtonColor: "#DD6B55",
			confirmButtonText: "确定",
			cancelButtonText: "取消",
			showLoaderOnConfirm: true,
			animation: true,
			allowOutsideClick: false
		}).then(function() {
			$scope.request("/menu/delete", {
				id: id
			}, function(data) {
				window.notie.alert({
					type: 1,
					text: data.Message,
					time: 4
				});
				scope.remove();
			});
		}, function() {
		}).catch(swal.noop);
	}
	$scope.edit= function(menu) {
		$scope.menu = menu;
		layer.open({
			type: 1,
			zIndex: 20,
			title: '修改菜单信息',
			area: (window.screen.width > 600 ? 600 : window.screen.width) + 'px',// '340px'], //宽高
			content: $("#modal"),
			success: function(layero, index) {
				$scope.menu = menu;
			},
			end: function() {
				$("#modal").css("display", "none");
			}
		});
	}
	
	$scope.submit = function (menu) {
		if (menu.Icon==""||menu.Icon==null||menu.Icon==undefined) {
			menu.Icon = null;
		}
		if (menu.Id) {
			//修改
			$scope.request("/menu/save", menu, function (data) {
				swal(data.Message, null, 'info');
				$scope.menu = {};
				$scope.closeAll();
			});
		}else {
			//添加
			menu.appid=$scope.appid;
			if (menu.ParentId) {
				//添加子菜单
				$scope.submenu.nodes.push(menu);
			} else {
				//添加主菜单
				var nodeData = $scope.data[$scope.data.length - 1] || {Sort:10,nodes:[]};
				menu.Sort = nodeData.Sort + (nodeData.nodes.length + 1) * 10;
				$scope.data.push(menu);
			}
			$scope.request("/menu/save", menu, function (data) {
				window.notie.alert({
					type: 1,
					text: data.Message,
					time: 3
				});
				$scope.menu = {};
				$scope.closeAll();
				//Custombox.close();
				$scope.init();
			});
		}
	}
	$scope.upload = function() {
		swal({
			title: '请选择一张图片',
			input: 'file',
			showCancelButton: true,
			showCloseButton: true,
			confirmButtonColor: "#DD6B55",
			confirmButtonText: "确定",
			cancelButtonText: "取消",
			showLoaderOnConfirm: true,
			animation: true,
			inputAttributes: {
				accept: 'image/*'
			}
		}).then(function(file) {
			if (file) {
				var reader = new FileReader;
				reader.onload = function (e) {
					swal({
						title: "上传预览",
						text:"确认后将开始上传并应用设置！",
						imageUrl: e.target.result,
						showCancelButton: true,
						confirmButtonColor: '#3085d6',
						cancelButtonColor: '#d33',
						confirmButtonText: '开始上传',
						cancelButtonText: '取消',
						showLoaderOnConfirm: true,
						preConfirm: function () {
							return new Promise(function (resolve, reject) {
								$http.post("/upload/DecodeDataUri", {
									data: e.target.result
								}).then(function (res) {
									var data = res.data;
									if (data.Success) {
										resolve(data.Data);
									} else {
										reject(data.Message);
									}
								}, function (error) {
									reject("请求失败，错误码：" + error.status);
								});
							});
						}
					}).then(function (data) {
						$scope.post.ImageUrl = data;
					}).catch(swal.noop);
				};
				reader.readAsDataURL(file);
			}
		}).catch(swal.noop);
	}
	$scope.init();
}]);
myApp.controller('menuPermission', ["$timeout", "$state", "$scope", "$http","$stateParams","NgTableParams", function($timeout, $state, $scope, $http,$stateParams,NgTableParams) {
	window.hub.disconnect();
	$scope.id=$stateParams.id;
	$scope.request("/menu/get/"+$scope.id,null, function(data) {
		$scope.menu=data.Data;
	});
	$scope.loading();
	var self = this;
		self.stats = [];
		self.data = {};
		$scope.kw = "";
		$scope.paginationConf = {
			currentPage: 1,
			itemsPerPage: 10,
			pagesLength: 25,
			perPageOptions: [1, 5, 10, 15, 20, 30, 40, 50, 100, 200],
			rememberPerPage: 'perPageItems',
			onChange: function() {
				self.GetPageData($scope.paginationConf.currentPage, $scope.paginationConf.itemsPerPage);
			}
		};
		$scope.paginationConf2 = {
			currentPage: 1,
			itemsPerPage: 10,
			pagesLength: 25,
			perPageOptions: [1, 5, 10, 15, 20, 30, 40, 50, 100, 200],
			rememberPerPage: 'perPageItems',
			onChange: function() {
				self.GetPageData($scope.paginationConf.currentPage, $scope.paginationConf.itemsPerPage);
			}
		};
		this.GetPageData = function(page, size) {
			$http.post("/menu/mypermissions", {
				id:$scope.id,
				page,
				size,
				kw: $scope.kw
			}).then(function(res) {
				$scope.paginationConf.totalItems = res.data.TotalCount;
				$("div[ng-table-pagination]").remove();
				self.tableParams = new NgTableParams({
					count: 50000
				}, {
					filterDelay: 0,
					dataset: res.data.Data.not
				});
				self.tableParams2 = new NgTableParams({
					count: 50000
				}, {
					filterDelay: 0,
					dataset: res.data.Data.my
				});
				$scope.loadingDone();
			});
		}
		var _timeout;
		$scope.search = function(kw) {
			if (_timeout) {
				$timeout.cancel(_timeout);
			}
			_timeout = $timeout(function() {
				$scope.kw = kw;
				self.GetPageData($scope.paginationConf.currentPage, $scope.paginationConf.itemsPerPage);
				_timeout = null;
			}, 500);
		}
	this.addPermissions= function(row) {
		$scope.request("/menu/AssignPermission", {
			id:$scope.id,
			pid:row.Id
		}, function(data) {
			if (data.Success) {
				self.GetPageData($scope.paginationConf.currentPage, $scope.paginationConf.itemsPerPage);
			}
		});
	}
	this.removePermissions= function(row) {
		$scope.request("/menu/RemovePermission", {
			id:$scope.id,
			pid:row.Id
		}, function(data) {
			if (data.Success) {
				self.GetPageData($scope.paginationConf.currentPage, $scope.paginationConf.itemsPerPage);
			}
		});
	}
}]);