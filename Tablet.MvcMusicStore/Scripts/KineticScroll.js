(function() {
  /**
   * Kinetic scroll for Webkit-based browsers on mobile devices
   *
   * Copyright (c) 2012 Dmitriy Kubyshkin (http://kubyshkin.ru)
   *
   * Licensed under the MIT license:
   *   http://www.opensource.org/licenses/mit-license.php
  */
  var BOUNCE_FRICTION, BOUNCE_MOVE_FRICTION, CHANGE_PAGE_VELOCITY, CHECK_SIZE_RATE, EVENT_DOWN, EVENT_MOVE, EVENT_UP, FRAME_RATE, FRICTION, KineticScroll, PAGINATED_FRICTION, PIXEL_RATIO, SCROLL_FADE_SPEED, SCROLL_PADDING, SCROLL_VISIBLE_OPACTITY, SCROLL_WIDTH, drawRoundRect, _ref;
  var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };
  drawRoundRect = function(ctx, sx, sy, ex, ey, r) {
    var r2d;
    r2d = Math.PI / 180;
    if ((ex - sx) - (2 * r) < 0) {
      r = (ex - sx) / 2;
    }
    if ((ey - sy) - (2 * r) < 0) {
      r = (ey - sy) / 2;
    }
    ctx.beginPath();
    ctx.moveTo(sx + r, sy);
    ctx.lineTo(ex - r, sy);
    ctx.arc(ex - r, sy + r, r, r2d * 270, r2d * 360, false);
    ctx.lineTo(ex, ey - r);
    ctx.arc(ex - r, ey - r, r, r2d * 0, r2d * 90, false);
    ctx.lineTo(sx + r, ey);
    ctx.arc(sx + r, ey - r, r, r2d * 90, r2d * 180, false);
    ctx.lineTo(sx, sy + r);
    ctx.arc(sx + r, sy + r, r, r2d * 180, r2d * 270, false);
    return ctx.closePath();
  };
  FRAME_RATE = 1000 / 60;
  CHECK_SIZE_RATE = 200;
  FRICTION = 0.96;
  PAGINATED_FRICTION = 0.99;
  BOUNCE_FRICTION = 0.75;
  BOUNCE_MOVE_FRICTION = 0.5;
  CHANGE_PAGE_VELOCITY = 4;
  if ((_ref = window.requestAnimationFrame) == null) {
    window.requestAnimationFrame = (function() {
      return window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame || (function() {
        var callbacks, handle, processCallbacks;
        callbacks = [];
        handle = null;
        processCallbacks = function() {
          var callback, copy, _i, _len, _results;
          copy = callbacks.slice();
          callbacks = [];
          handle = null;
          _results = [];
          for (_i = 0, _len = copy.length; _i < _len; _i++) {
            callback = copy[_i];
            _results.push(callback.apply(this));
          }
          return _results;
        };
        return function(callback) {
          if (callbacks.indexOf(callback) === -1) {
            callbacks.push(callback);
          }
          if (!handle) {
            return handle = setTimeout(processCallbacks, FRAME_RATE);
          }
        };
      })();
    })();
  }
  SCROLL_PADDING = 15;
  SCROLL_WIDTH = 6;
  SCROLL_VISIBLE_OPACTITY = 0.5;
  SCROLL_FADE_SPEED = 120;
  PIXEL_RATIO = window.devicePixelRatio || 1;
  if ('ontouchstart' in window) {
    EVENT_DOWN = 'touchstart';
    EVENT_MOVE = 'touchmove';
    EVENT_UP = 'touchend';
  } else {
    EVENT_DOWN = 'mousedown';
    EVENT_MOVE = 'mousemove';
    EVENT_UP = 'mouseup';
  }
  KineticScroll = (function() {
    KineticScroll.prototype.scrolling = false;
    KineticScroll.prototype.decelerating = false;
    KineticScroll.prototype.horizontalBar = null;
    KineticScroll.prototype.verticalBar = null;
    KineticScroll.prototype.horizontalThumbSize = 0;
    KineticScroll.prototype.verticalThumbSize = 0;
    KineticScroll.prototype.currentPageX = 0;
    KineticScroll.prototype.pageCountX = 1;
    KineticScroll.prototype.currentPageY = 0;
    KineticScroll.prototype.pageCountY = 1;
    KineticScroll.prototype.verticalProportion = 1;
    KineticScroll.prototype.horizontalProportion = 1;
    KineticScroll.prototype.parentSizeX = 0;
    KineticScroll.prototype.parentSizeY = 0;
    KineticScroll.prototype.contentSizeX = 0;
    KineticScroll.prototype.contentSizeY = 0;
    KineticScroll.prototype.contentAdjustedSizeX = 0;
    KineticScroll.prototype.contentAdjustedSizeY = 0;
    KineticScroll.prototype.velocityX = 0;
    KineticScroll.prototype.velocityY = 0;
    KineticScroll.prototype.offsetX = 0;
    KineticScroll.prototype.offsetY = 0;
    KineticScroll.prototype.minOffsetX = 0;
    KineticScroll.prototype.minOffsetY = 0;
    KineticScroll.prototype.maxOffsetX = 0;
    KineticScroll.prototype.maxOffsetY = 0;
    KineticScroll.prototype.lastX = 0;
    KineticScroll.prototype.lastY = 0;
    KineticScroll.prototype.originalTarget = null;
    KineticScroll.prototype.checkSizesTimeout = null;
    function KineticScroll(el, options) {
      var name, node, value, _base, _base2, _i, _len, _ref2, _ref3, _ref4;
      if (options == null) {
        options = {};
      }
      this.updateStyles = __bind(this.updateStyles, this);
      this.finishScroll = __bind(this.finishScroll, this);
      this.bounce = __bind(this.bounce, this);
      this.decelerate = __bind(this.decelerate, this);
      this.windowBlur = __bind(this.windowBlur, this);
      this.up = __bind(this.up, this);
      this.move = __bind(this.move, this);
      this.down = __bind(this.down, this);
      this.checkSizes = __bind(this.checkSizes, this);
      this.options = {
        vertical: true,
        horizontal: false,
        paginated: false,
        ignoredSelector: 'input, textarea, select'
      };
      for (name in options) {
        value = options[name];
        this.options[name] = value;
      }
      if ((_ref2 = (_base = this.options).verticalBar) == null) {
        _base.verticalBar = this.options.vertical;
      }
      if ((_ref3 = (_base2 = this.options).horizontalBar) == null) {
        _base2.horizontalBar = this.options.horizontal;
      }
      this.parent = el;
      el.style.overflow = 'hidden';
      _ref4 = this.parent.childNodes;
      for (_i = 0, _len = _ref4.length; _i < _len; _i++) {
        node = _ref4[_i];
        if (node.nodeType === Node.ELEMENT_NODE) {
          this.content = node;
          break;
        }
      }
      this.content.style.webkitTransform = 'translate3d(0,0,0)';
      if (this.options.vertical && this.options.verticalBar) {
        this.createBar('vertical');
      }
      if (this.options.horizontal && this.options.horizontalBar) {
        this.createBar('horizontal');
      }
      this.parent.addEventListener(EVENT_DOWN, this.down, true);
      this.checkSizesTimeout = setTimeout(this.checkSizes, CHECK_SIZE_RATE);
    }
    KineticScroll.prototype.destroy = function() {
      this.parent.removeEventListener(EVENT_DOWN, this.down, true);
      return clearTimeout(this.checkSizesTimeout);
    };
    KineticScroll.prototype.createBar = function(direction) {
      var bar;
      bar = document.createElement('canvas');
      bar.style.position = "absolute";
      bar.style.zIndex = 10000;
      bar.style.webkitTransition = "opacity " + SCROLL_FADE_SPEED + "ms linear";
      if (direction === 'vertical') {
        bar.style.top = "" + SCROLL_PADDING + "px";
        bar.style.width = "" + SCROLL_WIDTH + "px";
        bar.style.right = "" + SCROLL_WIDTH + "px";
      } else {
        bar.style.left = "" + SCROLL_PADDING + "px";
        bar.style.height = "" + SCROLL_WIDTH + "px";
        bar.style.bottom = "" + SCROLL_WIDTH + "px";
      }
      this.parent.appendChild(bar);
      return this["" + direction + "Bar"] = bar;
    };
    KineticScroll.prototype.checkSizes = function() {
      var contentHeight, contentWidth, parentHeight, parentWidth;
      if (this.scrolling) {
        return;
      }
      clearTimeout(this.checkSizesTimeout);
      parentHeight = this.parent.offsetHeight;
      contentHeight = this.content.offsetHeight;
      parentWidth = this.parent.offsetWidth;
      contentWidth = this.content.offsetWidth;
      if (!(parentHeight || contentHeight || parentWidth || contentWidth)) {
        return this.destroy();
      }
      if (parentWidth === this.parentSizeX && parentHeight === this.parentSizeY && contentWidth === this.contentSizeX && contentHeight === this.contentSizeY) {
        return this.checkSizesTimeout = setTimeout(this.checkSizes, CHECK_SIZE_RATE);
      }
      this.parentSizeX = parentWidth;
      this.parentSizeY = parentHeight;
      this.contentAdjustedSizeX = this.contentSizeX = contentWidth;
      this.contentAdjustedSizeX >= this.parentSizeX || (this.contentAdjustedSizeX = this.parentSizeX);
      this.contentAdjustedSizeY = this.contentSizeY = contentHeight;
      this.contentAdjustedSizeY >= this.parentSizeY || (this.contentAdjustedSizeY = this.parentSizeY);
      if (this.options.paginated) {
        if (this.options.horizontal) {
          this.checkCurrentPage('X');
        }
        if (this.options.vertical) {
          this.checkCurrentPage('Y');
        }
      } else {
        if (this.options.horizontal && this.offsetX !== 0 && parentWidth > this.contentAdjustedSizeX + this.offsetX) {
          this.calculateSizes();
          this.bounce('X');
        }
        if (this.options.vertical && this.offsetY !== 0 && parentHeight > this.contentAdjustedSizeY + this.offsetY) {
          this.calculateSizes();
          this.bounce('Y');
        }
      }
      return this.checkSizesTimeout = setTimeout(this.checkSizes, CHECK_SIZE_RATE);
    };
    KineticScroll.prototype.setCurrentPage = function(xOrY, page) {
      var currentPage;
      page < this["pageCount" + xOrY] || (page = this["pageCount" + xOrY] - 1);
      page >= 0 || (page = 0);
      currentPage = this["currentPage" + xOrY];
      this["currentPage" + xOrY] = page;
      if (currentPage !== page && typeof this.options.onCurrentPageChange === 'function') {
        return this.options.onCurrentPageChange.call(this, this["currentPage" + xOrY], xOrY.toLowerCase());
      }
    };
    KineticScroll.prototype.checkCurrentPage = function(xOrY) {
      this.calculatePages(xOrY);
      if (!(this["currentPage" + xOrY] >= this["pageCount" + xOrY])) {
        return;
      }
      this.setCurrentPage(xOrY, this["pageCount" + xOrY] - 1);
      return this.bounce(xOrY);
    };
    KineticScroll.prototype.calculateSizes = function() {
      var trackHeight, trackWidth;
      if (this.options.horizontal) {
        this.maxOffsetX = this.contentAdjustedSizeX - this.parentSizeX;
        if (this.options.paginated) {
          this.calculatePages('X');
        }
        if (this.options.horizontalBar) {
          trackWidth = this.parentSizeX - 2 * SCROLL_PADDING;
          this.horizontalBar.style.width = "" + trackWidth + "px";
          this.horizontalBar.setAttribute('width', trackWidth * PIXEL_RATIO);
          this.horizontalBar.setAttribute('height', this.horizontalBar.offsetHeight * PIXEL_RATIO);
          this.horizontalProportion = this.parentSizeX / this.contentAdjustedSizeX;
          this.horizontalThumbSize = this.horizontalProportion * trackWidth * PIXEL_RATIO;
          this.horizontalProportion *= trackWidth / this.parentSizeX;
        }
      }
      if (this.options.vertical) {
        this.maxOffsetY = this.contentAdjustedSizeY - this.parentSizeY;
        if (this.options.paginated) {
          this.calculatePages('Y');
        }
        if (this.options.verticalBar) {
          trackHeight = this.parentSizeY - 2 * SCROLL_PADDING;
          this.verticalBar.style.height = "" + trackHeight + "px";
          this.verticalBar.setAttribute('height', trackHeight * PIXEL_RATIO);
          this.verticalBar.setAttribute('width', this.verticalBar.offsetWidth * PIXEL_RATIO);
          this.verticalProportion = this.parentSizeY / this.contentAdjustedSizeY;
          this.verticalThumbSize = this.verticalProportion * trackHeight * PIXEL_RATIO;
          return this.verticalProportion *= trackHeight / this.parentSizeY;
        }
      }
    };
    KineticScroll.prototype.calculatePages = function(xOrY, range) {
      var newPageCount, proposed;
      if (range == null) {
        range = 1;
      }
      newPageCount = Math.ceil(this["contentAdjustedSize" + xOrY] / this["parentSize" + xOrY]);
      if (newPageCount !== this["pageCount" + xOrY]) {
        this["pageCount" + xOrY] = newPageCount;
        if (typeof this.options.onPageCountChange === 'function') {
          this.options.onPageCountChange.call(this, newPageCount, this["currentPage" + xOrY], xOrY.toLowerCase());
        }
      }
      this["minOffset" + xOrY] = (this["currentPage" + xOrY] - range) * this["parentSize" + xOrY];
      this["minOffset" + xOrY] >= 0 || (this["minOffset" + xOrY] = 0);
      this["maxOffset" + xOrY] = (this["pageCount" + xOrY] - 1) * this["parentSize" + xOrY];
      proposed = (this["currentPage" + xOrY] + range) * this["parentSize" + xOrY];
      if (proposed < this["maxOffset" + xOrY]) {
        return this["maxOffset" + xOrY] = proposed;
      }
    };
    KineticScroll.prototype.down = function(e) {
      var originalEvent;
      originalEvent = e;
      if (e.touches) {
        e = e.touches[0];
      } else {
        if (e.which !== 1) {
          return;
        }
      }
      this.originalTarget = e.target;
      if (this.originalTarget.webkitMatchesSelector(this.options.ignoredSelector)) {
        return;
      }
      originalEvent.preventDefault();
      this.scrolling = true;
      document.addEventListener(EVENT_MOVE, this.move, true);
      document.addEventListener(EVENT_UP, this.up, true);
      window.addEventListener('blur', this.windowBlur, true);
      this.velocityX = this.velocityY = 0;
      this.lastX = e.clientX;
      this.lastY = e.clientY;
      return this.calculateSizes();
    };
    KineticScroll.prototype.move = function(e) {
      e.preventDefault();
      if (e.touches) {
        e = e.touches[0];
      }
      if (this.options.horizontal) {
        this.velocityX = e.clientX - this.lastX;
      }
      if (this.options.vertical) {
        this.velocityY = e.clientY - this.lastY;
      }
      this.lastX = e.clientX;
      this.lastY = e.clientY;
      if (this.originalTarget) {
        this.originalTarget = null;
        if (this.options.verticalBar) {
          this.verticalBar.style.opacity = SCROLL_VISIBLE_OPACTITY;
        }
        if (this.options.horizontalBar) {
          this.horizontalBar.style.opacity = SCROLL_VISIBLE_OPACTITY;
        }
      }
      if (this.options.horizontal && (-this.offsetX < this.minOffsetX || -this.offsetX > this.maxOffsetX)) {
        this.velocityX *= BOUNCE_MOVE_FRICTION;
      }
      if (this.options.vertical && (-this.offsetY < this.minOffsetY || -this.offsetY > this.maxOffsetY)) {
        this.velocityY *= BOUNCE_MOVE_FRICTION;
      }
      if (this.options.horizontal) {
        this.offsetX += this.velocityX;
      }
      if (this.options.vertical) {
        this.offsetY += this.velocityY;
      }
      return requestAnimationFrame(this.updateStyles);
    };
    KineticScroll.prototype.up = function(e) {
      document.removeEventListener(EVENT_MOVE, this.move, true);
      document.removeEventListener(EVENT_UP, this.up, true);
      window.removeEventListener('blur', this.windowBlur, true);
      this.scrolling = false;
      if (this.originalTarget) {
        return;
      }
      if (this.options.horizontal) {
        if (this.options.paginated) {
          this.deceleratePaginated('X');
        } else {
          this.decelerate('X');
        }
      }
      if (this.options.vertical) {
        if (this.options.paginated) {
          return this.deceleratePaginated('Y');
        } else {
          return this.decelerate('Y');
        }
      }
    };
    KineticScroll.prototype.windowBlur = function() {
      this.originalTarget = null;
      return this.up();
    };
    KineticScroll.prototype.deceleratePaginated = function(xOrY) {
      var calculatedPage, currentPage;
      if (this.scrolling) {
        return;
      }
      currentPage = this["currentPage" + xOrY];
      calculatedPage = Math.round(-this["offset" + xOrY] / this["parentSize" + xOrY]);
      if (calculatedPage !== currentPage) {
        currentPage = calculatedPage;
      } else if (Math.abs(this["velocity" + xOrY]) > CHANGE_PAGE_VELOCITY) {
        currentPage += this["velocity" + xOrY] < 0 ? 1 : -1;
      }
      this.setCurrentPage(xOrY, currentPage);
      this["velocity" + xOrY] = 0;
      this.calculatePages(xOrY, 0);
      return this.bounce(xOrY);
    };
    KineticScroll.prototype.decelerate = function(xOrY) {
      var shouldBounce;
      if (this.scrolling) {
        return;
      }
      shouldBounce = -this["offset" + xOrY] < this["minOffset" + xOrY] || -this["offset" + xOrY] > this["maxOffset" + xOrY];
      if (Math.abs(this["velocity" + xOrY]) < 1) {
        this["velocity" + xOrY] = 0;
        if (shouldBounce) {
          return this.bounce(xOrY);
        } else {
          return this.finishScroll(xOrY);
        }
      }
      this["velocity" + xOrY] *= shouldBounce ? BOUNCE_FRICTION * FRICTION : FRICTION;
      this["offset" + xOrY] += this["velocity" + xOrY];
      requestAnimationFrame(this.updateStyles);
      return requestAnimationFrame(__bind(function() {
        return this.decelerate(xOrY);
      }, this));
    };
    KineticScroll.prototype.bounce = function(xOrY) {
      var realOffset;
      if (this.scrolling) {
        return;
      }
      realOffset = this["offset" + xOrY];
      realOffset += this["offset" + xOrY] < -this["minOffset" + xOrY] ? this["maxOffset" + xOrY] : this["minOffset" + xOrY];
      this["offset" + xOrY] -= realOffset * (1 - BOUNCE_FRICTION);
      if (Math.abs(realOffset) < 1) {
        return this.finishScroll(xOrY);
      } else {
        requestAnimationFrame(this.updateStyles);
        return requestAnimationFrame(__bind(function() {
          return this.bounce(xOrY);
        }, this));
      }
    };
    KineticScroll.prototype.finishScroll = function(xOrY) {
      this["offset" + xOrY] = Math.abs(this["offset" + xOrY] + this["minOffset" + xOrY]) < 1 ? -this["minOffset" + xOrY] : Math.ceil(this["offset" + xOrY]);
      this.content.style.webkitTransform = "translate3d(" + this.offsetX + "px," + this.offsetY + "px,0)";
      if (!(this.velocityX || this.velocityY)) {
        this.checkSizesTimeout = setTimeout(this.checkSizes, CHECK_SIZE_RATE);
      }
      if (xOrY === 'X') {
        if (this.options.horizontalBar) {
          return this.horizontalBar.style.opacity = 0;
        }
      } else {
        if (this.options.verticalBar) {
          return this.verticalBar.style.opacity = 0;
        }
      }
    };
    KineticScroll.prototype.updateStyles = function() {
      var bottom, ctx, height, offset, r, right, width;
      this.content.style.webkitTransform = "translate3d(" + this.offsetX + "px," + this.offsetY + "px,0)";
      r = SCROLL_WIDTH * PIXEL_RATIO;
      if (this.options.vertical && this.options.verticalBar) {
        height = this.verticalBar.offsetHeight * PIXEL_RATIO;
        ctx = this.verticalBar.getContext('2d');
        ctx.strokeStyle = '#fff';
        ctx.clearRect(0, 0, r, height);
        offset = -this.verticalProportion * this.offsetY * PIXEL_RATIO;
        bottom = this.verticalThumbSize + offset;
        if (bottom > height - 1) {
          bottom = height - 1;
        }
        if (bottom < r) {
          bottom = r;
        }
        if (offset < 1) {
          offset = 1;
        }
        if (offset > height - r) {
          offset = height - r;
        }
        drawRoundRect(ctx, 0.5, offset, r - 0.5, bottom, r / 2 - 1);
        ctx.fill();
        ctx.stroke();
      }
      if (this.options.horizontal && this.options.horizontalBar) {
        width = this.horizontalBar.offsetWidth * PIXEL_RATIO;
        ctx = this.horizontalBar.getContext('2d');
        ctx.strokeStyle = '#fff';
        ctx.clearRect(0, 0, width, r);
        offset = -this.horizontalProportion * this.offsetX * PIXEL_RATIO;
        right = this.horizontalThumbSize + offset;
        if (right > width - 1) {
          right = width - 1;
        }
        if (right < r) {
          right = r;
        }
        if (offset < 1) {
          offset = 1;
        }
        if (offset > width - r) {
          offset = width - r;
        }
        drawRoundRect(ctx, offset, 0.5, right, r - 0.5, r / 2 - 1);
        ctx.fill();
        return ctx.stroke();
      }
    };
    return KineticScroll;
  })();
  if (typeof module === 'object') {
    module.exports = KineticScroll;
  } else {
    window['KineticScroll'] = KineticScroll;
  }
}).call(this);
