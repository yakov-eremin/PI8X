/*
Copyright (C) 2020 by Morten Bøgeskov <source@kosmisk.dk>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#pragma once

#ifdef __cplusplus
extern "C" {
#endif

#include <libavcodec/avcodec.h>
#include <libavformat/avformat.h>
#include <libavutil/pixfmt.h>

/**
 * Data structure for mjpeg decoding
 */
struct v4l2_mjpeg_decoder {
	const AVCodec *codec;
	AVCodecContext *context;
	AVPacket *packet;
	AVFrame *frame;
};

/**
 * Initialize the mjpeg decoder.
 * The decoder must be destroyed on failure.
 *
 * @param props the decoder structure
 * @return non-zero on failure
 */
int v4l2_init_mjpeg(struct v4l2_mjpeg_decoder *decoder);

/**
 * Free any data associated with the decoder.
 *
 * @param decoder the decoder structure
 */
void v4l2_destroy_mjpeg(struct v4l2_mjpeg_decoder *decoder);

/**
 * Decode a jpeg into an obs frame
 *
 * @param out the obs frame to decode into
 * @param data the jpeg data
 * @param length length of the data
 * @param decoder the decoder as initialized by v4l2_init_mjpeg
 * @return non-zero on failure
 */
int v4l2_decode_mjpeg(struct obs_source_frame *out, uint8_t *data,
		      size_t length, struct v4l2_mjpeg_decoder *decoder);

#ifdef __cplusplus
}
#endif
