using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_NET104_TuanNDPH25862.Migrations
{
    public partial class Cayvcl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLieu",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChatLieu = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamChiTiet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDChatLieu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GiaBan = table.Column<int>(type: "int", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NhaCungCap = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamChiTiet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SanPhamChiTiet_ChatLieu_IDChatLieu",
                        column: x => x.IDChatLieu,
                        principalTable: "ChatLieu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNguoiDung = table.Column<string>(type: "nchar(256)", nullable: false),
                    IDCV = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatKhau = table.Column<string>(type: "nchar(256)", nullable: false),
                    HoTen = table.Column<string>(type: "nchar(256)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NguoiDung_ChucVu_IDCV",
                        column: x => x.IDCV,
                        principalTable: "ChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_GioHang_NguoiDung_UserID",
                        column: x => x.UserID,
                        principalTable: "NguoiDung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "Datetime", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    IDNguoiDung = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHD = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDon_NguoiDung_IDNguoiDung",
                        column: x => x.IDNguoiDung,
                        principalTable: "NguoiDung",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangChiTiet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangChiTiet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_GioHang_UserID",
                        column: x => x.UserID,
                        principalTable: "GioHang",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GioHangChiTiet_SanPhamChiTiet_IDSPCT",
                        column: x => x.IDSPCT,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonChiTiet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSPCT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonChiTiet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_HoaDon_IDHD",
                        column: x => x.IDHD,
                        principalTable: "HoaDon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonChiTiet_SanPhamChiTiet_IDSPCT",
                        column: x => x.IDSPCT,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiet_IDSPCT",
                table: "GioHangChiTiet",
                column: "IDSPCT");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangChiTiet_UserID",
                table: "GioHangChiTiet",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDNguoiDung",
                table: "HoaDon",
                column: "IDNguoiDung");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IDHD",
                table: "HoaDonChiTiet",
                column: "IDHD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonChiTiet_IDSPCT",
                table: "HoaDonChiTiet",
                column: "IDSPCT");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_IDCV",
                table: "NguoiDung",
                column: "IDCV");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IDChatLieu",
                table: "SanPhamChiTiet",
                column: "IDChatLieu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GioHangChiTiet");

            migrationBuilder.DropTable(
                name: "HoaDonChiTiet");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPhamChiTiet");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "ChatLieu");

            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
